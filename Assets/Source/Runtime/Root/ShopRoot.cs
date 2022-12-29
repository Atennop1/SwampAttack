using System.Collections.Generic;
using Sirenix.OdinInspector;
using SwampAttack.Runtime.Factories.WeaponFactories;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Player;
using SwampAttack.Runtime.Model.Shop;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Clients;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Shop.ProductsLists;
using SwampAttack.Runtime.Model.Wallet;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.View.Shop.ProductsLists;
using SwampAttack.Runtime.View.Wallet;
using SwampAttack.Runtime.View.Weapons;
using UnityEngine;

namespace SwampAttack.Runtime.Root
{
    public class ShopRoot : SerializedMonoBehaviour
    {
        [SerializeField] private IWeaponBulletsView _weaponBulletsView;
        [SerializeField] private IWalletView _walletView;
        [SerializeField] private IProductsListView<IProduct<IWeapon>> _productsListView;
        [SerializeField] private IWeaponProductProductsFactory _weaponProductProductsFactory;

        public void Compose(IInventory<IProduct<IWeapon>> weaponsInventory, IEnumerable<IProductCell<IProduct<IWeapon>>> cells)
        {
            var wallet = new Wallet<IMoney>(_walletView);
            var client = new Client<IProduct<IWeapon>>(wallet, weaponsInventory);
            
            _productsListView.Init(client);
            var productsList = new WeaponProductsList<Player>(new ProductsList<IProduct<IWeapon>>(cells), _weaponProductProductsFactory, _productsListView);
        }
    }
}