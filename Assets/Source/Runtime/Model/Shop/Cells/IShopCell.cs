namespace SwampAttack.Runtime.Model.Shop.Cells
{
    public interface IShopCell<T> : IReadOnlyShopCell<T>
    {
        bool CanTake(int count);
        void Merge(IShopCell<T> cell);
        void Take(int count);
    }
}