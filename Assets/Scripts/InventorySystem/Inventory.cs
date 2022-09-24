using System;
using System.Collections.Generic;

namespace SwampAttack.InventorySystem
{
    public sealed class Inventory<T> : IInventory<T>
    {
        public bool IsFull => _items.Count == _capacity;
        public IReadOnlyList<T> Items => _items;

        private int _capacity;
        private List<T> _items;

        public Inventory(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException($"Can't create inventory with capacity {capacity}");

            _capacity = capacity;
            _items = new List<T>();
        }

        public void Add(T item, int count = 1)
        {
            if (IsFull && (count += Items.Count) > _capacity)
                throw new ArgumentException($"Can't add {count} items in inventory");

            for (int i = 0; i < count; i++)
                _items.Add(item);
        }
    }
}