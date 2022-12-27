using SwampAttack.Runtime.Model.Shop;
using SwampAttack.Runtime.Model.Shop.Clients;
using SwampAttack.Runtime.Model.Shop.ProductsLists;

namespace SwampAttack.Runtime.View.Shop.ProductsLists
{
    public interface IProductsListView<T>
    {
        void Init(IClient<T> client);
        void Visualize(IProductsList<T> productsList);
    }
}