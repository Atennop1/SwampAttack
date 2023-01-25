namespace SwampAttack.Model.Shop
{
    public interface IReadOnlyProductCell<T>
    {
        int Count { get; }
        IProduct<T> Product { get; }
    }
}