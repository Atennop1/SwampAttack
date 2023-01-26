using System;
using SwampAttack.Tools;

namespace SwampAttack.Model.Shop
{
    public class ProductCell<T> : IProductCell<T>
    {
        public IProduct<T> Product { get; }
        public int Count { get; private set; }

        public ProductCell(IProduct<T> product, int count = 1)
        {
            Product = product ?? throw new ArgumentException("Product can't be null");
            Count = count.TryThrowIfLessOrEqualsZero();
        }

        public void Merge(IProductCell<T> anotherCell)
        {
            if (anotherCell == null)
                throw new ArgumentException("AnotherCell can't be null");

            Count += anotherCell.Count;
        }

        public void Take(int count)
        {
            if (Count < count)
                throw new ArgumentException("Requested count it too big");

            Count -= count.TryThrowIfLessOrEqualsZero();
        }
        
        public bool CanTake(int count) 
            => Count >= count.TryThrowIfLessOrEqualsZero();
    }
}