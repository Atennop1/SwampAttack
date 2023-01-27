using System;
using SwampAttack.Model.Shop;
using UnityEngine;

namespace SwampAttack.Tests.NullComponents
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