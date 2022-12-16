using System;
using System.Collections.Generic;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.View.Weapons.PlayerWeapons;

namespace SwampAttack.Runtime.Model.InventorySystem
{
    public class WeaponProductsInventory : IInventory<IProduct<IWeapon>>
    {
        private readonly IInventory<IProduct<IWeapon>> _inventory;
        private readonly IPlayerWeaponsView _weaponsView;

        public WeaponProductsInventory(IInventory<IProduct<IWeapon>> inventory, IPlayerWeaponsView weaponsView)
        {
            _inventory = inventory ?? throw new ArgumentException("Inventory can't be null");
            _weaponsView = weaponsView ?? throw new ArgumentException("WeaponsView can't be null");
        }

        public void Add(IProduct<IWeapon> item, int count = 1)
        {
            try
            {
                _inventory.Add(item, count);
                _weaponsView.Display(_inventory);
            }
            catch { throw; }
        }

        public bool IsFull => _inventory.IsFull;
        public IReadOnlyList<IProduct<IWeapon>> Items => _inventory.Items;
    }
}