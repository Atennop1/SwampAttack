using SwampAttack.Runtime.Factories;
using SwampAttack.Runtime.HealthSystem;
using SwampAttack.Runtime.Model.HealthSystem;
using SwampAttack.Runtime.Model.Input;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Root.Interfaces;
using SwampAttack.Runtime.View.Health;
using UnityEngine;

namespace SwampAttack.Runtime.Root
{
    public sealed class CharacterRoot : CompositeRoot
    {
        [SerializeField] private BulletsFactory _bulletsFactory;
        [SerializeField] private HealthTransformView _healthTransformView;

        [Space]
        [SerializeField] private PlayerRoot _playerRoot;
        [SerializeField] private IWeaponInput _weaponInput;

        public override void Compose()
        {
            IInventory<IWeapon> weaponInventory = new Inventory<IWeapon>(3);
            weaponInventory.Add(new Weapon(_bulletsFactory, 18));
            _healthTransformView.Init(new Health(5));

            var weapon = weaponInventory.Items[0];
            _playerRoot.Compose(new WeaponData(_weaponInput, weapon));
        }
    }
}