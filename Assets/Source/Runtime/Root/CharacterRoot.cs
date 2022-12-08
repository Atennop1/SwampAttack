using SwampAttack.Runtime.Factories;
using SwampAttack.Runtime.Model.HealthSystem;
using SwampAttack.Runtime.Model.Input;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Root.Interfaces;
using SwampAttack.Runtime.View.Health;
using SwampAttack.Runtime.View.Weapons;
using UnityEngine;

namespace SwampAttack.Runtime.Root
{
    public sealed class CharacterRoot : CompositeRoot
    {
        [SerializeField] private BulletsFactory _bulletsFactory;
        [SerializeField] private IWeaponInput _weaponInput;
        [SerializeField] private HealthTransformView _healthTransformView;
        
        [Space]
        [SerializeField] private IHealthView _playerHealthView;
        [SerializeField] private IWeaponBulletsView _weaponBulletsView;

        [Space] 
        [SerializeField] private ShopProductsRoot _productsRoot;
        [SerializeField] private ShopRoot _shopRoot;
        [SerializeField] private PlayerRoot _playerRoot;

        public override void Compose()
        {
            IInventory<IWeapon> weaponInventory = new Inventory<IWeapon>(3);
            var weapon = new Weapon(_bulletsFactory, _weaponBulletsView, 18);
            weaponInventory.Add(weapon);
            
            _shopRoot.Compose(weaponInventory, _productsRoot.Compose());
            
            _healthTransformView.Init(new Health(5, _playerHealthView));
            _playerRoot.Compose(new WeaponUsingInfo(_weaponInput, weapon));
        }
    }
}