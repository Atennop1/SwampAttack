using System;
using System.Collections.Generic;
using System.Linq;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Tools.SaveSystem;

namespace SwampAttack.Runtime.Model.Shop.ProductsLists
{
    public class WeaponProductsList : IProductsList<IProduct<IWeapon>>
    {
        private readonly IProductsList<IProduct<IWeapon>> _productsList;
        private readonly CollectionStorageWithNames<WeaponProductsList, IProductCell<IProduct<IWeapon>>> _storage;
        
        public IReadOnlyList<IReadOnlyProductCell<IProduct<IWeapon>>> Cells { get; }
        
        public WeaponProductsList(IProductsList<IProduct<IWeapon>> productsList)
        {
            _storage = new CollectionStorageWithNames<WeaponProductsList, IProductCell<IProduct<IWeapon>>>();
            _productsList = productsList ?? throw new ArgumentException("ProductsList can't be null");
            Cells = _storage.Exist() ? _storage.Load().ToList() : _productsList.Cells.ToList();
        }
        
        public void Add(IProduct<IProduct<IWeapon>> addingProduct, int count = 1)
        {
            
        }

        public void Take(IProduct<IProduct<IWeapon>> takingProduct, int count = 1)
        {
            _productsList.Take(takingProduct, count);
            var cellFromWhichTaking = _productsList.Cells.First(cell => cell.Product == takingProduct);
            
            if (cellFromWhichTaking == null)
                _storage.RemoveElement(cellFromWhichTaking);
        }
    }
}