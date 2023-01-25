using System;
using SwampAttack.SO;

namespace SwampAttack.Model.Shop
{
    public class Product<T> : IProduct<T>
    {
        public IProductData Data { get; }
        public T Item { get; }
        
        public Product(T item, IProductData data)
        {
            Data = data ?? throw new ArgumentException("ProductData can't be null");
            Item = item ?? throw new ArgumentException("Item can't be null");
        }
    }
}