using System;
using System.Collections.Generic;
using SwampAttack.Factories;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.Tools;
using SwampAttack.View.Weapons;

namespace SwampAttack.Model.InventorySystem
{
    public class WeaponProductsInventory<TUser> : IInventory<IProduct<IWeapon>>
    {
        private readonly IInventory<IProduct<IWeapon>> _inventory;
        private readonly IPlayerWeaponsView _weaponsView;
        
        private readonly StorageWithNames<TUser, WeaponSavingData> _weaponSavingDataStorage;
        private readonly List<WeaponSavingData> _savedData = new();

        public bool IsFull => _inventory.IsFull;
        public IReadOnlyList<IProduct<IWeapon>> Items => _inventory.Items;

        public WeaponProductsInventory(IPlayerWeaponsView weaponsView, IWeaponProductsFactory weaponProductsFactory, int capacity = 1)
        {
            if (weaponProductsFactory == null)
                throw new ArgumentException("WeaponProductsFactory can't be null");
                
            _weaponsView = weaponsView ?? throw new ArgumentException("WeaponsView can't be null");
            _inventory = new Inventory<IProduct<IWeapon>>(capacity);
            
            _weaponSavingDataStorage = new StorageWithNames<TUser, WeaponSavingData>();
            Load(weaponProductsFactory);
            _weaponsView.Display(_inventory);
        }

        public void Add(IProduct<IWeapon> item, int count = 1)
        {
            _inventory.Add(item, count);
            _weaponsView.Display(_inventory);
            
            _savedData.Add(new WeaponSavingData(item.Item));
            _weaponSavingDataStorage.Save(_savedData);
        }

        public void Clear()
        {
            _savedData.Clear();
            _inventory.Clear();
            _weaponSavingDataStorage.Save(_savedData);
        }

        private void Load(IWeaponProductsFactory weaponProductsFactory)
        {
            if (!_weaponSavingDataStorage.Exist()) 
                return;
            
            _inventory.Clear();
            foreach (var data in _weaponSavingDataStorage.Load<List<WeaponSavingData>>())
            {
                _savedData.Add(data);
                _inventory.Add(weaponProductsFactory.Create(data));
            }
        }
    }
}