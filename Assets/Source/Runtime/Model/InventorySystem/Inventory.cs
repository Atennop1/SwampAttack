using System;
using System.Collections.Generic;
using SwampAttack.Tools;

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
            _capacity = capacity.TryThrowIfLessThanZero();
            _items = new List<T>();
        }

        public void Add(T addingItem)
        {
            if (addingItem == null)
                throw new ArgumentNullException(nameof(addingItem));
            
            if (IsFull)
                throw new ArgumentException("Inventory is full");

            _items.Add(addingItem);
        }

        public void Remove(T decreasingSlot)
        {
            if (decreasingSlot == null)
                throw new ArgumentNullException(nameof(decreasingSlot));

            _items.Remove(decreasingSlot);
        }
    }
}