using System;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Wallet;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Shop.Clients
{
    public class Client<T> : IClient<T>
    {
        private readonly IWallet _wallet;
        private readonly IInventory<T> _inventory;

        public Client(IWallet wallet, IInventory<T> inventory)
        {
            _wallet = wallet ?? throw new ArgumentException("Wallet can't be null");
            _inventory = inventory ?? throw new ArgumentException("Inventory can't be null");
        }

        public void Buy(IProduct<T> product, IProductsList<T> productsList)
        {
            if (product == null)
                throw new ArgumentException("Product can't be null");
            
            if (productsList == null)
                throw new ArgumentException("ProductsList can't be null");
            
            if (!EnoughMoney(product))
                throw new InvalidOperationException("Not enough money!");
            
            _wallet.Take(product.Data.Cost);
            _inventory.Add(product.Item);
            productsList.Take(product);
        }

        public bool EnoughMoney(IProduct<T> product)
        {
            if (product == null)
                throw new ArgumentException("Product can't be null");

            return product.Data.Cost <= _wallet.Money;
        }
    }
}