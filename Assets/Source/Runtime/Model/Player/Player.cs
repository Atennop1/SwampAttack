using System;
using SwampAttack.Runtime.Model.Input;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.Root.SystemUpdates;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Player
{
    public sealed class Player : IUpdatable
    {
        public IWeapon Weapon { get; private set; }
        public IWeaponInput WeaponInput { get; private set; }

        private readonly Camera _camera;
        private readonly Transform _gunEndPosition;

        public Player(WeaponUsingInfo weaponUsingInfo, Camera camera, Transform gunEndPosition)
        {
            WeaponInput = weaponUsingInfo.Input ?? throw new ArgumentException("Can't switch to null weapon input");
            Weapon = weaponUsingInfo.Weapon ?? throw new ArgumentException("Can't switch to null weapon");
            
            _camera = camera ? camera : throw new ArgumentException("Camera can't be null");
            _gunEndPosition = gunEndPosition ? gunEndPosition : throw new ArgumentException("GunEndPosition can't be null");
        }

        public void SwitchWeapon(WeaponUsingInfo weaponUsingInfo)
        {
            WeaponInput = weaponUsingInfo.Input ?? throw new ArgumentException("Can't switch to null weapon input");
            Weapon = weaponUsingInfo.Weapon ?? throw new ArgumentException("Can't switch to null weapon");
            Weapon.VisualizeBullets();
        }

        public void Update()
        {
            if (Weapon.CanShoot && WeaponInput.IsActive)
                Weapon.Shoot((WeaponInput.TouchPosition - (Vector2)_camera.WorldToScreenPoint(_gunEndPosition.position)).normalized);
        }
    }
}