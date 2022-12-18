using System;
using SwampAttack.Runtime.Factories.WeaponFactories;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.Model.Weapons.Types;
using SwampAttack.Tests.NullComponents.Inventory;

namespace SwampAttack.Tests.NullComponents.Products
{
    public class NullWeaponProductsFactory : IWeaponProductsFactory
    {
        public IProduct<IWeapon> Create(WeaponSavingData savingData)
        {
            switch (savingData.Type)
            {
                case WeaponType.Pistol:
                    return new Product<IWeapon>(new Pistol(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), new NullProductData());
                
                case WeaponType.Shotgun:
                    return new Product<IWeapon>(new Shotgun(new NullBulletsFactory(), new NullWeaponBulletsView(), 1), new NullProductData());
                
                default:
                    throw new SystemException("Invalid WeaponType");
            }
        }
    }
}