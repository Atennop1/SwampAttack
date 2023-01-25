namespace SwampAttack.Model.Shop
{
    public interface IProductCell<T> : IReadOnlyProductCell<T>
    {
        bool CanTake(int count);
        void Merge(IProductCell<T> cell);
        void Take(int count);
    }
}