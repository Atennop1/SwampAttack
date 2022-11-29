using System.Collections.Generic;
using System.Linq;
using SwampAttack.Runtime.Factories;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Shop;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Clients;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Wallet;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Root.Interfaces;
using SwampAttack.Runtime.SO.Products;
using SwampAttack.Runtime.View.Wallet;
using SwampAttack.Runtime.View.Weapons;
using UnityEngine;

namespace SwampAttack.Runtime.Root
{
    public class ShopRoot : CompositeRoot
    {
        [SerializeField] private BulletsFactory _bulletsFactory;
        [SerializeField] private IWeaponBulletsView _weaponBulletsView;
        [SerializeField] private IWalletView _walletView;
        [SerializeField] private IProductData _pistolProductData;
        
        public override void Compose()
        {
            IInventory<IWeapon> weaponInventory = new Inventory<IWeapon>(3);
            var weapon = new Weapon(_bulletsFactory, _weaponBulletsView, 18);

            var weaponProduct = new Product<IWeapon>(weapon, _pistolProductData);
            var wallet = new Wallet<IMoney>(_walletView);

            var shop = new Shop<IWeapon>(new List<IShopCell<IWeapon>> { new ShopCell<IWeapon>(weaponProduct) });
            var client = new Client<IWeapon>(shop, wallet, weaponInventory);
            client.Buy(weaponProduct);
        }
    }
}