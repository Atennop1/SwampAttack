using Sirenix.OdinInspector;
using SwampAttack.Runtime.Model.Player;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.Root.Interfaces;
using SwampAttack.Runtime.Root.SystemUpdates;
using SwampAttack.Runtime.View.Weapons.PlayerWeapons;
using UnityEngine;

namespace SwampAttack.Runtime.Root
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