using SwampAttack.Runtime.Model.Shop.Products;

namespace SwampAttack.Runtime.Model.Shop.Cells
{
    public interface IReadOnlyShopCell<T>
    {
        int Count { get; }
        IProduct<T> Product { get; }
    }
}