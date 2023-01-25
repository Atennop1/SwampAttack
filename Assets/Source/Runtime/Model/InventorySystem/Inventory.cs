using System;
using System.Collections.Generic;

namespace SwampAttack.Model.InventorySystem
{
    public sealed class Inventory<T> : IInventory<T>
    {
        public bool IsFull => _items.Count == _capacity;
        public IReadOnlyList<T> Items => _items;

        private readonly int _capacity;
        private readonly List<T> _items;

        public Inventory(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException($"Can't create inventory with capacity {capacity}");

            _capacity = capacity;
            _items = new List<T>();
        }

        public void Add(T item, int count = 1)
        {
            if (IsFull)
                throw new ArgumentException("Inventory is full");
            
            if (count + Items.Count > _capacity)
                throw new ArgumentException($"{count} items won't fit in inventory");

            for (var i = 0; i < count; i++)
                _items.Add(item);
        }

        public void Clear() 
            => _items.Clear();
    }
}