using SwampAttack.Model.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace SwampAttack.View.Shop
{
    public class ProductView : MonoBehaviour, IProductView
    {
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _descriptionText;
        
        [Space]
        [SerializeField] private Image _icon;
        [SerializeField] private Text _costText;
        [field: SerializeField] public Button BuyButton { get; private set; }

        public void Init(IProductData data)
        {
            _nameText.text = data.Name;
            _descriptionText.text = data.Description;
            _costText.text = data.Cost.ToString();
            _icon.sprite = data.Sprite;
        }
    }
}