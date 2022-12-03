using System;
using System.Collections.Generic;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Tools.SaveSystem;

namespace SwampAttack.Runtime.Model.Shop
{
    public class ProductsList<T> : IProductsList<T>
    {
        public IReadOnlyList<IReadOnlyProductCell<T>> Cells => _cells;
        private readonly List<IProductCell<T>> _cells;
        private readonly CollectionStorageWithNames<ProductsList<T>, IProductCell<T>> _storage;

        public ProductsList(IEnumerable<IProductCell<T>> cells)
        {
            if (cells == null)
                throw new ArgumentException("ProductsList can't be null");
            
            _storage = new CollectionStorageWithNames<ProductsList<T>, IProductCell<T>>();
            _cells = (List<IProductCell<T>>)(_storage.Exist() ? _storage.Load() : cells);
        }

        public void Add(IProduct<T> addingProduct, int count = 1)
        {
            if (count < 1)
                throw new ArgumentException("Count can't be negative number");
            
            if (addingProduct == null)
                throw new ArgumentException("Can't add null product");

            if (_cells.Exists(cell => cell.Product == addingProduct))
            {
                var productCell = _cells.Find(cell => cell.Product == addingProduct);
                productCell.Merge(new ProductCell<T>(addingProduct, count));
                _storage.Save(productCell);
                return;
            }

            var newProductCell = new ProductCell<T>(addingProduct, count);
            _cells.Add(newProductCell);
            _storage.Save(newProductCell);
        }

        public void Take(IProduct<T> takingProduct, int count = 1)
        {
            if (takingProduct == null)
                throw new ArgumentException("Can't take null product");
            
            if (count < 1)
                throw new ArgumentException("Count can't be negative number");
            
            var cellFromWhichTaking = _cells.Find(cell => cell.Product == takingProduct);

            if (cellFromWhichTaking == null)
                throw new ArgumentException("Shop doesn't contains this product");
            
            if (!cellFromWhichTaking.CanTake(count))
                throw new ArgumentException("Cant take from this shop");
            
            cellFromWhichTaking.Take(count);
            if (cellFromWhichTaking.Count != 0) 
                return;
            
            _storage.RemoveElement(cellFromWhichTaking);
            Remove(cellFromWhichTaking.Product);
        }

        private void Remove(IProduct<T> removingProduct)
        {
            if (!_cells.Exists(cell => cell.Product == removingProduct))
                throw new ArgumentException("Requested cell doesn't contains in shop");

            var removingCell = _cells.Find(cell => cell.Product == removingProduct);
            _cells.Remove(removingCell);
            _storage.RemoveElement(removingCell);
        }
    }
}