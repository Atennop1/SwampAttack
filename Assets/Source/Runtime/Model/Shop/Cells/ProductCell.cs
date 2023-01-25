using System;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;

namespace SwampAttack.Runtime.Model.Shop.Cells
{
    public class ProductCell<T> : IProductCell<T>
    {
        public IProduct<T> Product { get; }
        public int Count { get; private set; }

        public ProductCell(IProduct<T> product, int count = 1)
        {
            if (count < 1)
                throw new ArgumentException("Count can't be negative number");
            
            Product = product ?? throw new ArgumentException("Product can't be null");
            Count = count;
        }

        public void Merge(IProductCell<T> anotherCell)
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
        
        public bool CanTake(int count) 
            => Count >= count;
    }
}