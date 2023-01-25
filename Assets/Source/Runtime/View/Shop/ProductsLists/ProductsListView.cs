using System;
using Sirenix.OdinInspector;
using SwampAttack.Model.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace SwampAttack.View.Shop
{
    public class ProductsListView<T> : SerializedMonoBehaviour, IProductsListView<T>
    {
        [SerializeField] private GameObject _productViewPrefab;
        [SerializeField] private GameObject _screen;
        [SerializeField] private Transform _scrollViewContent;
        
        [Space]
        [SerializeField] private Text _noItemsText;
        [SerializeField] private INotEnoughMoneyView _notEnoughMoneyView;
        
        private IClient<T> _client;

        public void Init(IClient<T> client)
            => _client = client ?? throw new ArgumentException("Client can't be null");

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

            DisplayNoItemsText(productsList);
        }

        public void Close() 
            => _screen.SetActive(false);

        public void Open() 
            => _screen.SetActive(true);

        private void DisplayNoItemsText(IProductsList<T> productsList)
        {
            _noItemsText.gameObject.SetActive(productsList.Cells.Count == 0);
        }

        private void ClearContent()
        {
            var childCount = _scrollViewContent.childCount;
            for (var i = 0; i < childCount; i++)
                Destroy(_scrollViewContent.GetChild(0).gameObject);
        }

        private void Awake()
        {
            if (_productViewPrefab.TryGetComponent<IProductView>(out _) == false)
                throw new ArgumentException("ProductViewPrefab must contains IProductView component");
        }
    }
}