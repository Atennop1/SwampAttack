using System;
using SwampAttack.Input;
using SwampAttack.Weapons;
using SwampAttack.Root.Update;

namespace SwampAttack.PlayerComponents
{
    public sealed class Player : IUpdatable
    {
        private IWeapon _weapon;
        private IWeaponInput _weaponInput;

        public Player((IWeaponInput, IWeapon) weapon)
        {
            _weaponInput = weapon.Item1;
            _weapon = weapon.Item2;
        }

        public void SwitchWeapon((IWeaponInput, IWeapon) newWeapon)
        {
            if (newWeapon.Item1 == null || newWeapon.Item2 == null)
                throw new ArgumentException("Can't switch to null weapon");

            _weaponInput = newWeapon.Item1;
            _weapon = newWeapon.Item2;
        }

        public void Update()
        {
            if (_weapon.CanShoot && _weaponInput.IsActive)
                _weapon.Shoot();
        }
    }
}