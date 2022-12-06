using SwampAttack.Runtime.SO.Products;
using UnityEngine.UI;

namespace SwampAttack.Runtime.View.Shop.Products
{
    public interface IProductView
    {
        Button BuyButton { get; }
        void Init(IProductData data);
    }
}