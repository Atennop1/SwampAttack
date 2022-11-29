namespace SwampAttack.Runtime.Model.Shop.Cells
{
    public interface IProductCell<T> : IReadOnlyProductCell<T>
    {
        bool CanTake(int count);
        void Merge(IProductCell<T> cell);
        void Take(int count);
    }
}