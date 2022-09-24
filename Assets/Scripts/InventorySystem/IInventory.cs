using System.Collections.Generic;

namespace SwampAttack.InventorySystem
{
    public interface IInventory<T>
    {
        bool IsFull { get; }
        IReadOnlyList<T> Items {get; }

        void Add(T item, int count = 1);
    }
}