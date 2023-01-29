using System;
using System.Collections.Generic;
using System.Linq;
using SwampAttack.Factories;
using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Weapons;
using SwampAttack.Tools;
using SwampAttack.View.Shop;

namespace SwampAttack.Model.Shop
{
    public class WeaponProductsList<TUser> : IProductsList<IInventorySlot<IProduct<IWeapon>>>
    {
        private readonly IProductsList<IInventorySlot<IProduct<IWeapon>>> _productsList;
        private readonly StorageWithNames<TUser, IProductsList<IProductCell<IProduct<IWeapon>>>> _storage;
        private readonly List<WeaponProductCellSavingData> _savingData;
        private readonly IProductsListView<IInventorySlot<IProduct<IWeapon>>> _view;
        
        public IReadOnlyList<IReadOnlyProductCell<IInventorySlot<IProduct<IWeapon>>>> Cells { get; }

        public WeaponProductsList(IProductsList<IInventorySlot<IProduct<IWeapon>>> productsList,
            IWeaponProductProductsFactory weaponProductProductsFactory, IProductsListView<IInventorySlot<IProduct<IWeapon>>> view)
        {
            if (weaponProductProductsFactory == null)
                throw new ArgumentException("ProductsList can't be null");

            _productsList = productsList ?? throw new ArgumentException("ProductsList can't be null");
            _storage = new StorageWithNames<TUser, IProductsList<IProductCell<IProduct<IWeapon>>>>();

            _view = view ?? throw new ArgumentException("View can't be null");

            _savingData = _storage.Exist()
                ? _storage.Load<List<WeaponProductCellSavingData>>()
                : new List<WeaponProductCellSavingData>();

            Cells = _storage.Exist()
                ? _savingData.Select(data => 
                    new ProductCell<IInventorySlot<IProduct<IWeapon>>>(weaponProductProductsFactory.Create(data.WeaponSavingData), data.CountInCell)).ToList()
                : _productsList.Cells.ToList();
            
            _view.Visualize(this);
        }

        public void Add(IProduct<IInventorySlot<IProduct<IWeapon>>> addingProduct, int count = 1)
        {
            _productsList.Add(addingProduct, count);
            _savingData.Add(new WeaponProductCellSavingData(new WeaponSavingData(addingProduct.Item.Item.Item),
                _productsList.Cells.Where(cell => cell.Product == addingProduct).ToList()[0].Count));
            
            _storage.Save(_savingData);
            _view.Visualize(_productsList);
        }

        public void Take(IProduct<IInventorySlot<IProduct<IWeapon>>> takingProduct, int count = 1)
        {
            _productsList.Take(takingProduct, count);

            _savingData.Remove(_savingData.Find(data =>
                data.WeaponSavingData.Type == takingProduct.Item.Item.Item.GetWeaponType()));

            if (_productsList.Cells.Count(cell => cell.Product == takingProduct) == 1)
            {
                _savingData.Add(new WeaponProductCellSavingData(new WeaponSavingData(takingProduct.Item.Item.Item),
                    _productsList.Cells.Where(cell => cell.Product == takingProduct).ToList()[0].Count));
            }

            _storage.Save(_savingData);
            _view.Visualize(_productsList);
        }
    }
}