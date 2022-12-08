using System.Collections.Generic;
using Sirenix.OdinInspector;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.SO.Products;
using UnityEngine;

namespace SwampAttack.Runtime.Root
{
    public class ShopProductsRoot : SerializedMonoBehaviour
    {
        [SerializeField] private List<WeaponData> _weaponData;
        [SerializeField] private List<IProductData> _productData;
        
        public IEnumerable<IProductCell<IWeapon>> Compose()
        {
            var result = new List<IProductCell<IWeapon>>();

            for (var i = 0; i < _weaponData.Count; i++)
            {
                result.Add(new ProductCell<IWeapon>(
                        new Product<IWeapon>(
                        new Weapon(_weaponData[i].BulletsFactory, _weaponData[i].BulletsView, _weaponData[i].Bullets),
                            _productData[i]))
                );
            }
            
            return result;
        }
    }
}