using UnityEngine;

namespace SwampAttack.Model.Shop
{
    public interface IProductData
    {
        string Name { get; }
        string Description { get; }
        
        Sprite Sprite { get; }
        int Cost { get; }
    }
}