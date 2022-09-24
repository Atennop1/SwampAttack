using UnityEngine;
using SwampAttack.Input;
using SwampAttack.Weapons;
using SwampAttack.Root.Update;
using SwampAttack.PlayerComponents;

namespace SwampAttack.Root
{
    public sealed class PlayerRoot : MonoBehaviour, IPlayerRoot
    {
        private Player _player;
        private ISystemUpdate _systemUpdate;

        public void Compose((IWeaponInput, IWeapon) weapon)
        {
            if (_player == null)
            {
                _systemUpdate = new SystemUpdate();
                _player = new Player(weapon);

                _systemUpdate.Add(_player);
                return;
            }

            _player.SwitchWeapon(weapon);
        }

        private void Update()
        {
            if (_systemUpdate != null)
                _systemUpdate.TryUpdateAll();
        } 
    }
}