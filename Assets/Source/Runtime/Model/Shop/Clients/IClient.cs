using SwampAttack.Runtime.Model.Shop.Products;

namespace SwampAttack.Runtime.Model.Shop.Clients
{
    public interface IClient<T>
    {
        void Buy(IProduct<T> product);
        bool EnoughMoney(IProduct<T> product);
    }
}