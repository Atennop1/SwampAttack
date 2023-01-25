using System;
using SwampAttack.SO;
using UnityEngine;

namespace SwampAttack.NullComponents
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