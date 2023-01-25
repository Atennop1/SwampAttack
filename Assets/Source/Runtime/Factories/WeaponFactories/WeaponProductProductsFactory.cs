using System;
using Sirenix.OdinInspector;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.SO;
using UnityEngine;

namespace SwampAttack.Factories
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