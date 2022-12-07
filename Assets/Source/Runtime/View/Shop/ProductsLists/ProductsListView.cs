using System;
using Sirenix.OdinInspector;
using SwampAttack.Runtime.Model.Shop;
using SwampAttack.Runtime.Model.Shop.Clients;
using SwampAttack.Runtime.View.Shop.Products;
using UnityEngine;

namespace SwampAttack.Runtime.View.Shop.ProductsLists
{
    public class ProductsListView<T> : SerializedMonoBehaviour, IProductsListView<T>
    {
        [SerializeField] private GameObject _productViewPrefab;
        [SerializeField] private Transform _scrollViewContent;
        [SerializeField] private INotEnoughMoneyView _notEnoughMoneyView;
        private IClient<T> _client;

        public void Init(IClient<T> client)
        {
            _client = client ?? throw new ArgumentException("Client can't be null");
        }

        public void Visualize(IProductsList<T> productsList)
        {
            if (productsList == null)
                throw new ArgumentException("ProductsList can't be null");
            
            ClearContent();
            
            foreach (var cell in productsList.Cells)
            {
                var productViewObject = Instantiate(_productViewPrefab, _scrollViewContent);
                var productView = productViewObject.GetComponent<IProductView>();
                
                productView.Init(cell.Product.Data);
                productView.BuyButton.onClick.AddListener(() =>
                {
                    if (!_client.EnoughMoney(cell.Product))
                    {
                        _notEnoughMoneyView.Display();
                        return;
                    }

                    _client.Buy(cell.Product, productsList);
                });
            }
        }

        private void ClearContent()
        {
            var childCount = _scrollViewContent.childCount;
            for (var i = 0; i < childCount; i++)
                Destroy(_scrollViewContent.GetChild(i));
        }

        private void Awake()
        {
            if (_productViewPrefab.TryGetComponent<IProductView>(out _) == false)
                throw new ArgumentException("ProductViewPrefab must contains IProductView component");
        }
    }
}