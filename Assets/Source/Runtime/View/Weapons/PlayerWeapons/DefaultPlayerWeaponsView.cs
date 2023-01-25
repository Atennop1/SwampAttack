using System;
using Sirenix.OdinInspector;
using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Player;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using UnityEngine;

namespace SwampAttack.View.Weapons
{
    public class DefaultPlayerWeaponsView : SerializedMonoBehaviour, IPlayerWeaponsView
    {
        [SerializeField] private IWeaponBulletsView _weaponBulletsView;
        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _slotViewPrefab;

        private Player _player;
        
        public void Display(IInventory<IProduct<IWeapon>> inventory)
        {
            if (_player == null)
                throw new InvalidOperationException("You need to init player first");
            
            if (inventory == null)
                throw new ArgumentException("Inventory can't be null");
            
            ClearContent();
            
            foreach (var product in inventory.Items)
            {
                var slotObject = Instantiate(_slotViewPrefab, _content);
                var slot = slotObject.GetComponent<IPlayerWeaponSlotView>();

                slot.UsingButton.onClick.AddListener(() =>
                {
                    _player.SwitchWeapon(new WeaponUsingInfo(_player.WeaponInput, product.Item));
                    _weaponBulletsView.Visualize(product.Item.Bullets, product.Item.MaxBullets);
                });
                
                slot.Init(product);
            }
        }

        public void Init(Player player) 
            => _player = player ?? throw new ArgumentException("Player can't be null");

        private void Awake()
        {
            if (_slotViewPrefab == null)
                throw new ArgumentException("SlotPrefab can't be null");
        }

        private void ClearContent()
        {
            var childCount = _content.childCount;
            for (var i = 0; i < childCount; i++)
                Destroy(_content.transform.GetChild(0).gameObject);
        }
    }
}