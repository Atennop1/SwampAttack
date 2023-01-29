using System;
using SwampAttack.Factories;
using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;

namespace SwampAttack.Tests.NullComponents
{
    public class NullWeaponProductProductsFactory : IWeaponProductProductsFactory
    {
        public IProduct<IInventorySlot<IProduct<IWeapon>>> Create(WeaponSavingData weaponSavingData)
        {
            var nullWeaponProductsFactory = new NullWeaponProductsFactory();

            return weaponSavingData.Type switch
            {
                WeaponType.Pistol => new Product<IInventorySlot<IProduct<IWeapon>>>(
                    new InventorySlot<IProduct<IWeapon>>(nullWeaponProductsFactory.Create(new WeaponSavingData(new Pistol(new NullBulletsFactory(),
                        new NullWeaponBulletsView(), 1)))), new NullProductData()),
                
                WeaponType.Shotgun => new Product<IInventorySlot<IProduct<IWeapon>>>(
                    new InventorySlot<IProduct<IWeapon>>(nullWeaponProductsFactory.Create(new WeaponSavingData(new Shotgun(new NullBulletsFactory(),
                        new NullWeaponBulletsView(), 1)))), new NullProductData()),
                
                _ => throw new SystemException("Invalid WeaponType")
            };
        }
    }
}