using System;
using SwampAttack.Model.Weapons;
using SwampAttack.Tools;

namespace SwampAttack.Model.InventorySystem
{
    [Serializable]
    public readonly struct WeaponProductSlotSavingData
    {
        public readonly WeaponSavingData WeaponSavingData;
        public readonly int ItemCount;
        public readonly bool IsSelected;

        public WeaponProductSlotSavingData(WeaponSavingData weaponSavingData, int itemCount, bool isSelected)
        {
            WeaponSavingData = weaponSavingData;
            ItemCount = itemCount.TryThrowIfLessOrEqualsZero();
            IsSelected = isSelected;
        }
    }
}