using System;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Wallet;
using SwampAttack.Runtime.Model.Weapons;

namespace SwampAttack.Runtime.Model.Shop.Clients
{
    public class WeaponClient : IClient<IWeapon>
    {
        private readonly IWallet _wallet;
        private readonly IInventory<IWeapon> _inventory;
        
        public WeaponClient(IWallet wallet, IInventory<IWeapon> inventory)
        {
            _wallet = wallet ?? throw new ArgumentException("Wallet can't be null");
            _inventory = inventory ?? throw new ArgumentException("Inventory can't be null");
        }

        public void Buy(IProduct<IWeapon> product)
        {
            if (!EnoughMoney(product))
                throw new InvalidOperationException("Not enough money!");
            
            _inventory.Add(product.Item);
        }

        public bool EnoughMoney(IProduct<IWeapon> product)
        {
            if (product == null)
                throw new ArgumentException("Product can't be null");

            return product.Data.Cost <= _wallet.Money;
        }
    }
}