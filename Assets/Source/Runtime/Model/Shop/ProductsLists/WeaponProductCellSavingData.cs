using System;
using SwampAttack.Model.Weapons;

namespace SwampAttack.Model.Shop
{
    [Serializable]
    public struct WeaponProductCellSavingData
    {
        public readonly WeaponSavingData WeaponSavingData;
        public readonly int CountInCell;

        public WeaponProductCellSavingData(WeaponSavingData weaponSavingData, int countInCell)
        {
            if (countInCell < 0)
                throw new ArgumentException("CountInCell can't be negative number");
            
            if (countInCell == 0)
                throw new ArgumentException("CountInCell can't be zero");
            
            WeaponSavingData = weaponSavingData;
            CountInCell = countInCell;
        }
    }
}