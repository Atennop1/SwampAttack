using SwampAttack.Root.Interfaces;
using SwampAttack.Root.SystemUpdates;
using SwampAttack.Weapons;
using UnityEngine;

namespace SwampAttack.Root
{
    public sealed class PlayerRoot : MonoBehaviour, IPlayerRoot
    {
        private Player.Player _player;
        private ISystemUpdate _systemUpdate;

        public void Compose(WeaponData weaponData)
        {
            if (_player == null)
            {
                _systemUpdate = new SystemUpdate();
                _player = new Player.Player(weaponData);

                _systemUpdate.Add(_player);
                return;
            }

            _player.SwitchWeapon(weaponData);
        }

        private void Update() =>  _systemUpdate?.UpdateAll();
    }
}