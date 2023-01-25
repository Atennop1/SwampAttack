using System.Collections.Generic;

namespace SwampAttack.Model.Shop
{
    public interface IProductsList<T>
    {
        IReadOnlyList<IReadOnlyProductCell<T>> Cells { get; }
        void Add(IProduct<T> addingProduct, int count = 1);
        void Take(IProduct<T> takingProduct, int count = 1);
    }
}