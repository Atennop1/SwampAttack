using System;
using SwampAttack.Factories;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;

namespace SwampAttack.Tests.NullComponents
{
    public class NullWeaponProductsFactory : IWeaponProductsFactory
    {
        public IProduct<IWeapon> Create(WeaponSavingData savingData)
        {
            return savingData.Type switch
            {
                WeaponType.Pistol => new Product<IWeapon>(
                    new Pistol(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), new NullProductData()),
                
                WeaponType.Shotgun => new Product<IWeapon>(
                    new Shotgun(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), new NullProductData()),
                
                _ => throw new SystemException("Invalid WeaponType")
            };
        }
    }
}