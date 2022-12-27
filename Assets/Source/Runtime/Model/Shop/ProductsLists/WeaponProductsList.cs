using System;
using System.Collections.Generic;
using System.Linq;
using SwampAttack.Runtime.Factories.WeaponFactories;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.Tools.SaveSystem;

namespace SwampAttack.Runtime.Model.Shop.ProductsLists
{
    public class WeaponProductsList<TUser> : IProductsList<IProduct<IWeapon>>
    {
        private readonly IProductsList<IProduct<IWeapon>> _productsList;
        private readonly StorageWithNames<TUser, IProductsList<IProductCell<IProduct<IWeapon>>>> _storage;
        
        public IReadOnlyList<IReadOnlyProductCell<IProduct<IWeapon>>> Cells { get; }
        
        public WeaponProductsList(IProductsList<IProduct<IWeapon>> productsList, IWeaponProductProductsFactory weaponProductProductsFactory)
        {
            if (weaponProductProductsFactory == null)
                throw new ArgumentException("ProductsList can't be null");
            
            _productsList = productsList ?? throw new ArgumentException("ProductsList can't be null");
            _storage = new StorageWithNames<TUser, IProductsList<IProductCell<IProduct<IWeapon>>>>();
            
            Cells = _storage.Exist() 
                ? _storage.Load<List<WeaponProductCellSavingData>>()
                    .Select(data => new ProductCell<IProduct<IWeapon>>(weaponProductProductsFactory.Create(data.WeaponSavingData), data.CountInCell)).ToList() 
                : _productsList.Cells.ToList();
        }
        
        public void Add(IProduct<IProduct<IWeapon>> addingProduct, int count = 1)
        {
            _productsList.Add(addingProduct, count);
            _storage.Save(_productsList.Cells.Select(cell => new WeaponProductCellSavingData(new WeaponSavingData(cell.Product.Item.Item), cell.Count)).ToList());
        }

        public void Take(IProduct<IProduct<IWeapon>> takingProduct, int count = 1)
        {
            _productsList.Take(takingProduct, count);
            _storage.Save(_productsList.Cells.Select(cell => new WeaponProductCellSavingData(new WeaponSavingData(cell.Product.Item.Item), cell.Count)).ToList());
        }
    }
}