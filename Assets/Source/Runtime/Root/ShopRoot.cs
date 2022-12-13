using System.Collections.Generic;
using Sirenix.OdinInspector;
using SwampAttack.Runtime.Model.InventorySystem;
using SwampAttack.Runtime.Model.Shop;
using SwampAttack.Runtime.Model.Shop.Cells;
using SwampAttack.Runtime.Model.Shop.Clients;
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
        [SerializeField] private IProductsListView<IWeapon> _productsListView;

        public void Compose(IInventory<IWeapon> weaponsInventory, IEnumerable<IProductCell<IWeapon>> cells)
        {
            var wallet = new Wallet<IMoney>(_walletView);
            var client = new Client<IWeapon>(wallet, weaponsInventory);
            
            _productsListView.Init(client);
            var productsList = new ProductsList<IWeapon>(_productsListView, cells);
        }
    }
}