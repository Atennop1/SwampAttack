using SwampAttack.Runtime.Model.Shop.Products;

namespace SwampAttack.Runtime.Model.Shop.Cells
{
    public interface IReadOnlyProductCell<T>
    {
        int Count { get; }
        IProduct<T> Product { get; }
    }
}