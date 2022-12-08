using System;
using SwampAttack.Runtime.Model.Input;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Root.SystemUpdates;

namespace SwampAttack.Runtime.Model.Player
{
    public sealed class Player : IUpdatable
    {
        private IWeapon _weapon;
        private IWeaponInput _weaponInput;

        public Player(WeaponUsingInfo weaponUsingInfo) => SwitchWeapon(weaponUsingInfo);

        public void SwitchWeapon(WeaponUsingInfo weaponUsingInfo)
        {
            _weaponInput = weaponUsingInfo.Input ?? throw new ArgumentException("Can't switch to null weapon input");
            _weapon = weaponUsingInfo.Weapon ?? throw new ArgumentException("Can't switch to null weapon");
        }

        public void Update()
        {
            if (_weapon.CanShoot && _weaponInput.IsActive)
                _weapon.Shoot();
        }
    }
}