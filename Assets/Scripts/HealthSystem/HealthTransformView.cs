using System;
using UnityEngine;

namespace SwampAttack.HealthSystem
{
    public sealed class HealthTransformView : MonoBehaviour
    {
        public IHealth Health { get; private set; }

        public void Init(IHealth health)
        {
            Health = health ?? throw new ArgumentException("Can't init null health");
        }
    }
}