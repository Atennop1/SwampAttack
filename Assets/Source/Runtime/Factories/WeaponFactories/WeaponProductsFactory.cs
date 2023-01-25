using System;
using Sirenix.OdinInspector;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.SO;
using UnityEngine;

namespace SwampAttack.Factories
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