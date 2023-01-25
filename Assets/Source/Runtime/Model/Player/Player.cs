using System;
using SwampAttack.Model.Input;
using SwampAttack.Model.Weapons;
using SwampAttack.Root;

namespace SwampAttack.Model.Player
{
    public sealed class Player : IUpdatable
    {
        public IWeaponInput WeaponInput { get; private set; }
        private IWeapon _weapon;

        public Player(WeaponUsingInfo weaponUsingInfo)
        {
            WeaponInput = weaponUsingInfo.Input ?? throw new ArgumentException("Can't switch to null weapon input");
            _weapon = weaponUsingInfo.Weapon ?? throw new ArgumentException("Can't switch to null weapon");
        }

        public void SwitchWeapon(WeaponUsingInfo weaponUsingInfo)
        {
            WeaponInput = weaponUsingInfo.Input ?? throw new ArgumentException("Can't switch to null weapon input");
            _weapon = weaponUsingInfo.Weapon ?? throw new ArgumentException("Can't switch to null weapon");
        }

        public void Update()
        {
            if (_weapon.CanShoot && WeaponInput.IsActive)
                _weapon.Shoot(WeaponInput.ShootDirection);
        }
    }
}