using System;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.SO.Products;

namespace SwampAttack.Runtime.Model.Shop.Products
{
    public class WeaponProduct : IProduct<IWeapon>
    {
        public IProductData Data { get; }
        public IWeapon Item { get; }
        
        public WeaponProduct(IWeapon item, IProductData data)
        {
            Data = data ?? throw new ArgumentException("ProductData can't be null");
            Item = item ?? throw new ArgumentException("Item can't be null");
        }
    }
}