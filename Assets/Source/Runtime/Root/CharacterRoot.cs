using System.Linq;
using SwampAttack.Runtime.Factories;
using SwampAttack.Runtime.Factories.WeaponFactories;
using SwampAttack.Runtime.Model.HealthSystem;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Player;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Bullets;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.Model.Weapons.Types;
using SwampAttack.Runtime.Root.Interfaces;
using SwampAttack.Runtime.SO.Products;
using SwampAttack.Runtime.Tools.Extensions;
using SwampAttack.Runtime.View.Health;
using SwampAttack.Runtime.View.Weapons;
using SwampAttack.Runtime.View.Weapons.PlayerWeapons;
using UnityEngine;

namespace SwampAttack.Runtime.Root
{
    public sealed class CharacterRoot : CompositeRoot
    {
        [SerializeField] private IFactory<IBullet> _bulletsFactory;
        [SerializeField] private IWeaponProductsFactory _weaponProductsFactory;
        [SerializeField] private IProductData _pistolProductData;

        [Space]
        [SerializeField] private IHealthTransformView _healthTransformView;
        [SerializeField] private IHealthView _playerHealthView;
        [SerializeField] private IWeaponBulletsView _weaponBulletsView;
        [SerializeField] private IPlayerWeaponsView _weaponsView;

        [Space] 
        [SerializeField] private ShopProductsRoot _productsRoot;
        [SerializeField] private ShopRoot _shopRoot;
        [SerializeField] private PlayerRoot _playerRoot;
        [SerializeField] private InputRoot _inputRoot;

        public override void Compose()
        {
            var weapon = new Pistol(_bulletsFactory, _weaponBulletsView, 18);
            _playerRoot.Compose(new WeaponUsingInfo(_inputRoot.Compose(), weapon));

            var weaponProductsInventory = new WeaponProductsInventory<Player>(_weaponsView, _weaponProductsFactory, 10);
            
            if (weaponProductsInventory.Items.Count(item => item.Item.GetWeaponType() == weapon.GetWeaponType()) == 0)
                weaponProductsInventory.Add(new Product<IWeapon>(weapon, _pistolProductData));

            _shopRoot.Compose(weaponProductsInventory, _productsRoot.Compose());
            _healthTransformView.Init(new Health(5, _playerHealthView));
        }
    }
}