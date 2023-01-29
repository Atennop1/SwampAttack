using System.Linq;
using SwampAttack.Factories;
using SwampAttack.Model.HealthSystem;
using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Player;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.Tools;
using SwampAttack.View.Health;
using SwampAttack.View.Weapons;
using UnityEngine;

namespace SwampAttack.Root
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

            if (weaponProductsInventory.Items.Count(slot => slot.Item.Item.GetWeaponType() == weapon.GetWeaponType()) == 0)
            {
                weaponProductsInventory.Add(new InventorySlot<IProduct<IWeapon>>(new Product<IWeapon>(weapon, _pistolProductData)));
            }
            else
            {
                _playerRoot.Compose(new WeaponUsingInfo(_inputRoot.Compose(), weaponProductsInventory.SelectedProduct.Item));
            }

            _shopRoot.Compose(weaponProductsInventory, _productsRoot.Compose());
            _healthTransformView.Init(new Health(5, _playerHealthView));
        }
    }
}