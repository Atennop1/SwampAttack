using SwampAttack.Model.Shop;
using SwampAttack.View.Shop;

namespace SwampAttack.Tests.NullComponents
{
    public class NullProductsListView<T> : IProductsListView<T>
    {
        public void Init(IClient<T> client) { }
        public void Visualize(IProductsList<T> productsList) { }
    }
}