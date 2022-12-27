using System.Collections.Generic;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;

namespace SwampAttack.Runtime.Model.Shop.ProductsLists
{
    public interface IProductsList<T>
    {
        IReadOnlyList<IReadOnlyProductCell<T>> Cells { get; }
        void Add(IProduct<T> addingProduct, int count = 1);
        void Take(IProduct<T> takingProduct, int count = 1);
    }
}