using System.Collections.Generic;
using Sirenix.OdinInspector;
using SwampAttack.Factories;
using SwampAttack.Model.InventorySystem;
using SwampAttack.Model.Player;
using SwampAttack.Model.Shop;
using SwampAttack.Model.Wallet;
using SwampAttack.Model.Weapons;
using SwampAttack.View.Shop;
using SwampAttack.View.Wallet;
using SwampAttack.View.Weapons;
using UnityEngine;

namespace SwampAttack.Root
{
    public class ShopRoot : SerializedMonoBehaviour
    {
        [SerializeField] private IWeaponBulletsView _weaponBulletsView;
        [SerializeField] private IWalletView _walletView;
        [SerializeField] private IProductsListView<IProduct<IWeapon>> _productsListView;
        [SerializeField] private IWeaponProductProductsFactory _weaponProductProductsFactory;
        [SerializeField] private PhysicsRewardsFactory _physicsRewardsFactory;

        public void Compose(IInventory<IProduct<IWeapon>> weaponsInventory, IEnumerable<IProductCell<IProduct<IWeapon>>> cells)
        {
            var wallet = new Wallet<IMoney>(_walletView);
            var client = new Client<IProduct<IWeapon>>(wallet, weaponsInventory);
            _physicsRewardsFactory.Init(wallet);
            
            _productsListView.Init(client);
            var productsList = new WeaponProductsList<Player>(new ProductsList<IProduct<IWeapon>>(cells), _weaponProductProductsFactory, _productsListView);
        }
    }
}