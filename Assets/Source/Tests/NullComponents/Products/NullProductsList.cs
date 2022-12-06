using System.Collections.Generic;
using SwampAttack.Runtime.Model.Shop;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using UnityEngine.Events;

namespace SwampAttack.Tests.NullComponents.Products
{
    public class NullProductsList<T> : IProductsList<T>
    {
        public IReadOnlyList<IReadOnlyProductCell<T>> Cells { get; }
        public void Add(IProduct<T> addingProduct, int count = 1) { } 
        public void Take(IProduct<T> takingProduct, int count = 1) { }
    }
}