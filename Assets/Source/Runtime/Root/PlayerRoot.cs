using Sirenix.OdinInspector;
using SwampAttack.Model.Player;
using SwampAttack.Model.Weapons;
using SwampAttack.View.Weapons;
using UnityEngine;

namespace SwampAttack.Root
{
    public sealed class PlayerRoot : SerializedMonoBehaviour, IPlayerRoot
    {
        [SerializeField] private IPlayerWeaponsView _weaponsView;

        private Player _player;
        private ISystemUpdate _systemUpdate;

        public void Compose(WeaponUsingInfo weaponUsingInfo)
        {
            if (_player == null)
            {
                _systemUpdate = new SystemUpdate();
                _player = new Player(weaponUsingInfo);

                _weaponsView.Init(_player);
                _systemUpdate.Add(_player);
                return;
            }

            _player.SwitchWeapon(weaponUsingInfo);
        }

        private void Update() 
            => _systemUpdate?.UpdateAll();
    }
}