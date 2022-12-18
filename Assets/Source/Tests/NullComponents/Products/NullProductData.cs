using System;
using SwampAttack.Runtime.SO.Products;
using UnityEngine;

namespace SwampAttack.Tests.NullComponents.Products
{
    [Serializable]
    public class NullProductData : IProductData
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Sprite { get; }
        public int Cost { get; }
    }
}