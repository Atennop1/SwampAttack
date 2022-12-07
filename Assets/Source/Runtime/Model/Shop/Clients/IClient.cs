using SwampAttack.Runtime.Model.Shop.Products;

namespace SwampAttack.Runtime.Model.Shop.Clients
{
    public interface IClient<T>
    {
        void Buy(IProduct<T> product, IProductsList<T> productsList);
        bool EnoughMoney(IProduct<T> product);
    }
}