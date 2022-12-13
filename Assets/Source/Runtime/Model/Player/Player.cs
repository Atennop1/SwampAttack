using System;
using SwampAttack.Runtime.Model.Input;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Root.SystemUpdates;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Player
{
    public sealed class Player : IUpdatable
    {
        private IWeapon _weapon;
        private IWeaponInput _weaponInput;

        private readonly Camera _camera;
        private readonly Transform _weaponGunEndPosition;

        public Player(WeaponUsingInfo weaponUsingInfo, Camera camera, Transform weaponGunEndPosition)
        {
            SwitchWeapon(weaponUsingInfo);
            _camera = camera;
            _weaponGunEndPosition = weaponGunEndPosition;
        }

        public void SwitchWeapon(WeaponUsingInfo weaponUsingInfo)
        {
            _weaponInput = weaponUsingInfo.Input ?? throw new ArgumentException("Can't switch to null weapon input");
            _weapon = weaponUsingInfo.Weapon ?? throw new ArgumentException("Can't switch to null weapon");
        }

        public void Update()
        {
            if (_weapon.CanShoot && _weaponInput.IsActive)
                _weapon.Shoot((_weaponInput.TouchPosition - (Vector2)_camera.WorldToScreenPoint(_weaponGunEndPosition.position)).normalized);
        }
    }
}