namespace SwampAttack.Model.Shop
{
    public interface IClient<T>
    {
        void Buy(IProduct<T> product, IProductsList<T> productsList);
        bool EnoughMoney(IProduct<T> product);
    }
}