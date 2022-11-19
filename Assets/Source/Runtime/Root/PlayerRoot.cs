using SwampAttack.Runtime.Model.Player;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Root.Interfaces;
using SwampAttack.Runtime.Root.SystemUpdates;
using UnityEngine;

namespace SwampAttack.Runtime.Root
{
    public sealed class PlayerRoot : MonoBehaviour, IPlayerRoot
    {
        private Player _player;
        private ISystemUpdate _systemUpdate;

        public void Compose(WeaponData weaponData)
        {
            if (_player == null)
            {
                _systemUpdate = new SystemUpdate();
                _player = new Player(weaponData);

                _systemUpdate.Add(_player);
                return;
            }

            _player.SwitchWeapon(weaponData);
        }

        private void Update() =>  _systemUpdate?.UpdateAll();
    }
}