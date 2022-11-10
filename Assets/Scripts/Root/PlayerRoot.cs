using SwampAttack.Root.Interfaces;
using Update = SwampAttack.Root.SystemUpdate;
using SwampAttack.Weapons;
using UnityEngine;

namespace SwampAttack.Root
{
    public sealed class PlayerRoot : MonoBehaviour, IPlayerRoot
    {
        private Player.Player _player;
        private Update.ISystemUpdate _systemUpdate;

        public void Compose(WeaponData weaponData)
        {
            if (_player == null)
            {
                _systemUpdate = new Update.SystemUpdate();
                _player = new Player.Player(weaponData);

                _systemUpdate.Add(_player);
                return;
            }

            _player.SwitchWeapon(weaponData);
        }

        private void Update() =>  _systemUpdate?.UpdateAll();
    }
}