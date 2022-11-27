using UnityEngine;

namespace SwampAttack.Runtime.SO.Products
{
    public interface IProductData
    {
        string Name { get; }
        string Description { get; }
        
        Sprite Sprite { get; }
        int Cost { get; }
    }
}