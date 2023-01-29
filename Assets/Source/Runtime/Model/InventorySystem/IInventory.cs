using System.Collections.Generic;

namespace SwampAttack.Model.InventorySystem
{
    public interface IInventory<T>
    {
        bool IsFull { get; }
        IReadOnlyList<T> Items {get; }
        
        void Add(T addingSlot);
        void Remove(T decreasingSlot);
    }
}