using System;
using System.Collections.Generic;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Clients;
using SwampAttack.Runtime.Model.Shop.Products;

namespace SwampAttack.Runtime.Model.Shop
{
    public class Shop<T> : IShop<T>
    {
        public IReadOnlyList<IReadOnlyShopCell<T>> Cells => _cells;
        private readonly List<IShopCell<T>> _cells;
        
        public Shop(List<IShopCell<T>> cells)
        {
            _cells = cells ?? throw new ArgumentException("ProductsList can't be null");
        }

        public void Add(IProduct<T> addingProduct, int count = 1)
        {
            if (count < 1)
                throw new ArgumentException("Count can't be negative number");
            
            if (addingProduct == null)
                throw new ArgumentException("Can't add null product");

            if (_cells.Exists(cell => cell.Product == addingProduct))
            {
                _cells.Find(cell => cell.Product == addingProduct).Merge(new ShopCell<T>(addingProduct, count));
                return;
            }
            
            _cells.Add(new ShopCell<T>(addingProduct, count));
        }

        public void Take(IProduct<T> takingProduct, int count = 1)
        {
            var cellFromWhichTaking = _cells.Find(cell => cell.Product == takingProduct);

            if (cellFromWhichTaking == null)
                throw new ArgumentException("Shop doesn't contains this product");
            
            if (!cellFromWhichTaking.CanTake(count))
                throw new ArgumentException("Cant take from this shop");
            
            cellFromWhichTaking.Take(count);
            if (cellFromWhichTaking.Count == 0)
                Remove(cellFromWhichTaking.Product);
        }

        private void Remove(IProduct<T> removingProduct)
        {
            if (!_cells.Exists(cell => cell.Product == removingProduct))
                throw new ArgumentException("Requested cell doesn't contains in shop");
            
            _cells.Remove(_cells.Find(cell => cell.Product == removingProduct));
        }
    }
}