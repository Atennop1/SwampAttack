using System;
using SwampAttack.Model.Weapons;
using SwampAttack.Tools;

namespace SwampAttack.Model.Shop
{
    [Serializable]
    public struct WeaponProductCellSavingData
    {
        public readonly WeaponSavingData WeaponSavingData;
        public readonly int CountInCell;

        public WeaponProductCellSavingData(WeaponSavingData weaponSavingData, int countInCell)
        {
            WeaponSavingData = weaponSavingData;
            CountInCell = countInCell.TryThrowIfLessOrEqualsZero();
        }
    }
}