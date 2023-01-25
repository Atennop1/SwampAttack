using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using SwampAttack.SO;
using UnityEngine;

namespace SwampAttack.Root
{
    public class ShopProductsRoot : SerializedMonoBehaviour
    {
        [SerializeField] private List<WeaponData> _weaponData;
        [SerializeField] private List<IProductData> _productData;
        
        public IEnumerable<IProductCell<IProduct<IWeapon>>> Compose()
        {
            var result = new List<IProductCell<IProduct<IWeapon>>>();

            for (var i = 0; i < _weaponData.Count; i++)
            {
                var weaponData = _weaponData[i];

                IWeapon weapon = weaponData.Type switch
                {
                    WeaponType.Pistol => new Pistol(weaponData.BulletsFactory, weaponData.BulletsView,
                        weaponData.Bullets),
                    WeaponType.Shotgun => new Shotgun(weaponData.BulletsFactory, weaponData.BulletsView,
                        weaponData.Bullets),
                    _ => throw new ArgumentException("Invalid WeaponType")
                };

                result.Add(new ProductCell<IProduct<IWeapon>>(
                    new Product<IProduct<IWeapon>>(new Product<IWeapon>(weapon, _productData[i]), _productData[i])));
            }
            
            return result;
        }
    }
}