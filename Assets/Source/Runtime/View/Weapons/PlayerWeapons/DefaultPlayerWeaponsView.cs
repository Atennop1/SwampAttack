using System;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using UnityEngine;

namespace SwampAttack.Runtime.View.Weapons.PlayerWeapons
{
    public class DefaultPlayerWeaponsView : MonoBehaviour, IPlayerWeaponsView
    {
        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _slotViewPrefab;
        
        public void Display(IInventory<IProduct<IWeapon>> inventory)
        {
            if (inventory == null)
                throw new ArgumentException("Inventory can't be null");
            
            ClearContent();

            foreach (var product in inventory.Items)
            {
                var slotObject = Instantiate(_slotViewPrefab, _content);
                var slot = slotObject.GetComponent<IPlayerWeaponSlotView>();
                slot.Init(product);
            }
        }

        private void Awake()
        {
            if (_slotViewPrefab == null)
                throw new ArgumentException("SlotPrefab can't be null");
        }

        private void ClearContent()
        {
            var childCount = _content.childCount;
            for (var i = 0; i < childCount; i++)
                Destroy(_content.transform.GetChild(0));
        }
    }
}