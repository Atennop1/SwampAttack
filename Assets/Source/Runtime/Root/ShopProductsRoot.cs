using System.Collections.Generic;
using Sirenix.OdinInspector;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.SO.Products;
using UnityEngine;

namespace SwampAttack.Runtime.Root
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
                result.Add(new ProductCell<IProduct<IWeapon>>
                    (
                        new Product<IProduct<IWeapon>>
                        (
                            new Product<IWeapon> (new Weapon(weaponData.BulletsFactory, weaponData.BulletsView, weaponData.Bullets), _productData[i]),
                            _productData[i]
                        )
                    )
                );
            }
            
            return result;
        }
    }
}