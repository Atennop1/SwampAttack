using SwampAttack.Model.Shop;

namespace SwampAttack.View.Shop
{
    public interface IProductsListView<T>
    {
        void Init(IClient<T> client);
        void Visualize(IProductsList<T> productsList);
    }
}