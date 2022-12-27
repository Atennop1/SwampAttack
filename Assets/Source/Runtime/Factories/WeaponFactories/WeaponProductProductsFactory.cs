using System;
using Sirenix.OdinInspector;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.SO.Products;
using UnityEngine;

namespace SwampAttack.Runtime.Factories.WeaponFactories
{
    public class WeaponProductProductsFactory : SerializedMonoBehaviour, IWeaponProductProductsFactory
    {
        [SerializeField] private IWeaponProductsFactory _weaponProductsFactory;
        
        [Space]
        [SerializeField] private IProductData _pistolProductsData;
        [SerializeField] private IProductData _shotgunProductData;
        
        public IProduct<IProduct<IWeapon>> Create(WeaponSavingData weaponSavingData)
        {
            return weaponSavingData.Type switch
            {
                WeaponType.Pistol => new Product<IProduct<IWeapon>>(_weaponProductsFactory.Create(weaponSavingData), _pistolProductsData),
                WeaponType.Shotgun => new Product<IProduct<IWeapon>>(_weaponProductsFactory.Create(weaponSavingData), _shotgunProductData),
                _ => throw new Exception("Invalid WeaponType")
            };
        }
    }
}