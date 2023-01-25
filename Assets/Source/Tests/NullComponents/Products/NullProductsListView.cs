using SwampAttack.Runtime.Model.Shop.Clients;
using SwampAttack.Runtime.Model.Shop.ProductsLists;
using SwampAttack.Runtime.View.Shop.ProductsLists;

namespace SwampAttack.Tests.NullComponents.Products
{
    public class NullProductsListView<T> : IProductsListView<T>
    {
        public void Init(IClient<T> client) { }
        public void Visualize(IProductsList<T> productsList) { }
    }
}