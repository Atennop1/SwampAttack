namespace SwampAttack.Model.InventorySystem
{
    public interface IInventorySlot<T>
    {
        T Item { get; }
        
        int ItemCount { get; }
        void IncreaseCount(int count);
        void DecreaseCount(int count);
        
        bool IsSelected { get; }
        void Select();
        void Unselect();
    }
}