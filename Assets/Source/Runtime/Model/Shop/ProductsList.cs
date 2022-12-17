using System;
using System.Collections.Generic;
using System.Linq;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Tools.SaveSystem;
using SwampAttack.Runtime.View.Shop.ProductsLists;

namespace SwampAttack.Runtime.Model.Shop
{
    public class ProductsList<T> : IProductsList<T>
    {
        public IReadOnlyList<IReadOnlyProductCell<T>> Cells => _cells;
        private readonly List<IProductCell<T>> _cells;
        
        private readonly CollectionStorageWithNames<ProductsList<T>, IProductCell<T>> _storage;
        private readonly IProductsListView<T> _view;

        public ProductsList(IProductsListView<T> view, IEnumerable<IProductCell<T>> cells)
        {
            if (cells == null)
                throw new ArgumentException("ProductsList can't be null");
            
            _storage = new CollectionStorageWithNames<ProductsList<T>, IProductCell<T>>();
            _cells = _storage.Exist() ? _storage.Load().ToList() : cells.ToList();
            
            _view = view ?? throw new ArgumentException("View can't be null");
            _view.Visualize(this);
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
            _view.Visualize(this);
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
            _view.Visualize(this);
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