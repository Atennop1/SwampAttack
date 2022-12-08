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

        public void Compose(WeaponUsingInfo weaponUsingInfo)
        {
            if (_player == null)
            {
                _systemUpdate = new SystemUpdate();
                _player = new Player(weaponUsingInfo);

                _systemUpdate.Add(_player);
                return;
            }

            _player.SwitchWeapon(weaponUsingInfo);
        }

        private void Update() =>  _systemUpdate?.UpdateAll();
    }
}