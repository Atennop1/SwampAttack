using UnityEngine;

namespace SwampAttack.SO
{
    public interface IProductData
    {
        string Name { get; }
        string Description { get; }
        
        Sprite Sprite { get; }
        int Cost { get; }
    }
}