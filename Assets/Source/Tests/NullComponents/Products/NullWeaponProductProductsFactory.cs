using System;
using SwampAttack.Runtime.Factories.WeaponFactories;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.Model.Weapons.Types;
using SwampAttack.Tests.NullComponents.Inventory;

namespace SwampAttack.Tests.NullComponents.Products
{
    public class NullWeaponProductProductsFactory : IWeaponProductProductsFactory
    {
        public IProduct<IProduct<IWeapon>> Create(WeaponSavingData weaponSavingData)
        {
            var nullWeaponProductsFactory = new NullWeaponProductsFactory();

            return weaponSavingData.Type switch
            {
                WeaponType.Pistol => new Product<IProduct<IWeapon>>(
                    nullWeaponProductsFactory.Create(new WeaponSavingData(new Pistol(new NullBulletsFactory(),
                        new NullWeaponBulletsView(), 1))), new NullProductData()),
                
                WeaponType.Shotgun => new Product<IProduct<IWeapon>>(
                    nullWeaponProductsFactory.Create(new WeaponSavingData(new Shotgun(new NullBulletsFactory(),
                        new NullWeaponBulletsView(), 1))), new NullProductData()),
                
                _ => throw new SystemException("Invalid WeaponType")
            };
        }
    }
}