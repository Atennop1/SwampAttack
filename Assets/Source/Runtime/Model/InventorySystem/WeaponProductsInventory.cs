using System;
using System.Collections.Generic;
using System.Linq;
using SwampAttack.Factories;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.Tools;
using SwampAttack.View.Weapons;
using UnityEngine;

namespace SwampAttack.Model.InventorySystem
{
    public class WeaponProductsInventory<TUser> : IWeaponProductsInventory
    {
        private readonly IInventory<IInventorySlot<IProduct<IWeapon>>> _inventory;
        private readonly IPlayerWeaponsView _weaponsView;
        
        private readonly StorageWithNames<TUser, List<WeaponProductSlotSavingData>> _weaponSavingDataStorage = new();
        private readonly List<WeaponProductSlotSavingData> _savedData = new();

        public bool IsFull => _inventory.IsFull;
        public IReadOnlyList<IInventorySlot<IProduct<IWeapon>>> Items => _inventory.Items;
        public IProduct<IWeapon> SelectedProduct { get; private set; }
        
        public void Select(IProduct<IWeapon> product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            
            var productSlot = Items.ToList().Find(slot => slot.Item == product);
            if (productSlot == null)
                throw new ArgumentException("Requested product doesn't contains in inventory");
            
            foreach (var slot in Items)
                slot.Unselect();

            SelectedProduct = product;
            productSlot.Select();
        }

        public WeaponProductsInventory(IPlayerWeaponsView weaponsView, IWeaponProductsFactory weaponProductsFactory, int capacity = 1)
        {
            if (weaponProductsFactory == null)
                throw new ArgumentException("WeaponProductsFactory can't be null");
                
            _weaponsView = weaponsView ?? throw new ArgumentException("WeaponsView can't be null");
            _inventory = new Inventory<IInventorySlot<IProduct<IWeapon>>>(capacity);

            Load(weaponProductsFactory);
            _weaponsView.Display(this);
        }

        public void Add(IInventorySlot<IProduct<IWeapon>> addingSlot)
        {
            var existingSlot = Items.ToList().Find(slot => slot.Item.Item.GetWeaponType() == addingSlot.Item.Item.GetWeaponType());

            if (existingSlot == null)
            {
                _inventory.Add(addingSlot);
                _savedData.Add(new WeaponProductSlotSavingData(new WeaponSavingData(addingSlot.Item.Item), addingSlot.ItemCount, addingSlot.IsSelected));
            }
            else
            {
                existingSlot.IncreaseCount(addingSlot.ItemCount);
                _savedData.Remove(_savedData.Find(data => data.WeaponSavingData.Type == addingSlot.Item.Item.GetWeaponType()));
                _savedData.Add(new WeaponProductSlotSavingData(new WeaponSavingData(existingSlot.Item.Item), existingSlot.ItemCount, existingSlot.IsSelected));
            }

            _weaponsView.Display(this);
            _weaponSavingDataStorage.Save(_savedData);
        }

        public void Remove(IInventorySlot<IProduct<IWeapon>> decreasingSlot)
        {
            var existingSlot = Items.ToList().Find(slot => slot == decreasingSlot);
            if (existingSlot == null)
                throw new ArgumentException("Item in slot doesn't contains in this inventory");
            
            _inventory.Remove(existingSlot);
            _weaponsView.Display(this);
            
            _savedData.Remove(_savedData.Find(data => data.WeaponSavingData.Type == existingSlot.Item.Item.GetWeaponType()));
            _weaponSavingDataStorage.Save(_savedData);
        }

        private void Load(IWeaponProductsFactory weaponProductsFactory)
        {
            if (!_weaponSavingDataStorage.Exist()) 
                return;

            ClearItems();
            foreach (var data in _weaponSavingDataStorage.Load<List<WeaponProductSlotSavingData>>())
            {
                _savedData.Add(data);
                var newSlot = new InventorySlot<IProduct<IWeapon>>(weaponProductsFactory.Create(data.WeaponSavingData), data.ItemCount);

                if (data.IsSelected)
                {
                    SelectedProduct = newSlot.Item;
                    newSlot.Select();
                }

                _inventory.Add(newSlot);
            }
        }

        private void ClearItems()
        {
            foreach (var slot in _inventory.Items)
                _inventory.Remove(slot);
        }
    }
}