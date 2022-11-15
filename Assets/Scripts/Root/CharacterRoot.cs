using System.Threading.Tasks;
using UnityEngine;
using SwampAttack.Input;
using SwampAttack.Weapons;
using SwampAttack.Factories;
using SwampAttack.HealthSystem;
using SwampAttack.InventorySystem;
using SwampAttack.Root.Interfaces;

namespace SwampAttack.Root
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