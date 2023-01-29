using System;
using SwampAttack.Tools;
using UnityEngine;

namespace SwampAttack.Model.InventorySystem
{
    public class InventorySlot<T> : IInventorySlot<T>
    {
        public T Item { get; }
        public int ItemCount { get; private set; }
        public bool IsSelected { get; private set; }

        public InventorySlot(T item, int count = 1)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
            ItemCount = count.TryThrowIfLessOrEqualsZero();
        }

        public void IncreaseCount(int count)
        {
            Debug.Log("slot before: " + ItemCount);
            ItemCount += count.TryThrowIfLessOrEqualsZero();
            Debug.Log("slot after: " + ItemCount);
        }

        public void DecreaseCount(int count)
        {
            if (ItemCount < count.TryThrowIfLessOrEqualsZero())
                throw new ArgumentException("Can't take too much items");

            ItemCount -= count;
        }

        public void Select()
            => IsSelected = true;

        public void Unselect()
            => IsSelected = false;
    }
}