using System;
using System.Collections.Generic;
using System.Linq;
using SwampAttack.Runtime.Factories.WeaponFactories;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.Tools.SaveSystem;
using SwampAttack.Runtime.View.Weapons.PlayerWeapons;

namespace SwampAttack.Runtime.Model.InventorySystem
{
    public class WeaponProductsInventory<TUser> : IInventory<IProduct<IWeapon>>
    {
        private readonly IInventory<IProduct<IWeapon>> _inventory;
        private readonly IPlayerWeaponsView _weaponsView;
        private readonly CollectionStorageWithNames<TUser, WeaponSavingData> _weaponSavingDataStorage;
        
        public bool IsFull => _inventory.IsFull;
        public IReadOnlyList<IProduct<IWeapon>> Items => _inventory.Items;

        public WeaponProductsInventory(IPlayerWeaponsView weaponsView, IWeaponProductsFactory weaponProductsFactory, int capacity = 1)
        {
            if (weaponProductsFactory == null)
                throw new ArgumentException("WeaponsFactory can't be null");
                
            _weaponsView = weaponsView ?? throw new ArgumentException("WeaponsView can't be null");
            _inventory = new Inventory<IProduct<IWeapon>>(capacity);
            
            _weaponSavingDataStorage = new CollectionStorageWithNames<TUser, WeaponSavingData>();
            Load(weaponProductsFactory);
        }

        public void Add(IProduct<IWeapon> item, int count = 1)
        {
            _inventory.Add(item, count);
            _weaponsView.Display(_inventory);
            _weaponSavingDataStorage.Save(new WeaponSavingData(item.Item));
        }

        private void Load(IWeaponProductsFactory weaponProductsFactory)
        {
            if (!_weaponSavingDataStorage.Exist()) 
                return;
            
            foreach (var data in _weaponSavingDataStorage.Load().ToList())
                _inventory.Add(weaponProductsFactory.Create(data));
        }
    }
}