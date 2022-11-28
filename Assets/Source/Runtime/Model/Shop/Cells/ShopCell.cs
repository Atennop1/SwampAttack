using System;
using SwampAttack.Runtime.Model.Shop.Products;

namespace SwampAttack.Runtime.Model.Shop.Cells
{
    public class ShopCell<T> : IShopCell<T>
    {
        public IProduct<T> Product { get; }
        public int Count { get; private set; }
        
        public ShopCell(IProduct<T> product, int count = 1)
        {
            if (count < 1)
                throw new ArgumentException("Count can't be negative number");
            
            Product = product ?? throw new ArgumentException("Product can't be null");
            Count = count;
        }

        public void Merge(IShopCell<T> anotherCell)
        {
            if (anotherCell == null)
                throw new ArgumentException("AnotherCell can't be null");

            Count += anotherCell.Count;
        }

        public void Take(int count)
        {
            if (count < 1)
                throw new ArgumentException("Count can't be negative number");
            
            if (Count < count)
                throw new ArgumentException("Requested count it too big");

            Count -= count;
        }
        
        public bool CanTake(int count) => Count >= count;
    }
}