using SwampAttack.SO;

namespace SwampAttack.Model.Shop
{
    public interface IProduct<T>
    {
        IProductData Data { get; }
        T Item { get; }
    }
}