using System;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Player;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using UnityEngine;

namespace SwampAttack.Runtime.View.Weapons.PlayerWeapons
{
    public class DefaultPlayerWeaponsView : MonoBehaviour, IPlayerWeaponsView
    {
        [SerializeField] private Player _player;
        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _slotViewPrefab;
        
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

                slot.UsingButton.onClick.AddListener(() => _player.SwitchWeapon(new WeaponUsingInfo(_player.WeaponInput, product.Item)));
                slot.Init(product);
            }
        }

        public void Init(Player player) => _player = player ?? throw new ArgumentException("Player can't be null");

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