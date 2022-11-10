using System;
using SwampAttack.Input;
using SwampAttack.Root.SystemUpdate;
using SwampAttack.Weapons;

namespace SwampAttack.Player
{
    public sealed class Player : IUpdatable
    {
        private IWeapon _weapon;
        private IWeaponInput _weaponInput;

        public Player(WeaponData weaponData) => SwitchWeapon(weaponData);

        public void SwitchWeapon(WeaponData weaponData)
        {
            _weaponInput = weaponData.Input ?? throw new ArgumentException("Can't switch to null weapon input");
            _weapon = weaponData.Weapon ?? throw new ArgumentException("Can't switch to null weapon");
        }

        public void Update()
        {
            if (_weapon.CanShoot && _weaponInput.IsActive)
                _weapon.Shoot();
        }
    }
}