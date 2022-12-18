using System;
using Sirenix.OdinInspector;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.SO.Products;
using UnityEngine;

namespace SwampAttack.Runtime.Factories.WeaponFactories
{
    public class WeaponProductsFactory : SerializedMonoBehaviour, IWeaponProductsFactory
    {
        [SerializeField] private IWeaponsFactory _weaponsFactory;

        [Space]
        [SerializeField] private IProductData _pistolProductsData;
        [SerializeField] private IProductData _shotgunProductData;

        public IProduct<IWeapon> Create(WeaponSavingData savingData)
        {
            return savingData.Type switch
            {
                WeaponType.Pistol => new Product<IWeapon>(_weaponsFactory.Create(savingData), _pistolProductsData),
                WeaponType.Shotgun => new Product<IWeapon>(_weaponsFactory.Create(savingData), _shotgunProductData),
                _ => throw new Exception("Invalid WeaponType")
            };
        }
    }
}