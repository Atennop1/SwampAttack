using SwampAttack.SO;
using UnityEngine.UI;

namespace SwampAttack.View.Shop
{
    public interface IProductView
    {
        Button BuyButton { get; }
        void Init(IProductData data);
    }
}