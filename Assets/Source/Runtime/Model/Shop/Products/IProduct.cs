using SwampAttack.Runtime.SO.Products;

namespace SwampAttack.Runtime.Model.Shop.Products
{
    public interface IProduct<T>
    {
        IProductData Data { get; }
        T Item { get; }
    }
}