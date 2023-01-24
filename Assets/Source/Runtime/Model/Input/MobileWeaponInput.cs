using System;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Input
{
    public class MobileWeaponInput : IWeaponInput
    {
        private readonly IShootDirectionCalculator _shootDirectionCalculator;

        public MobileWeaponInput(IShootDirectionCalculator shootDirectionCalculator)
            => _shootDirectionCalculator = shootDirectionCalculator ?? throw new ArgumentNullException(nameof(shootDirectionCalculator));
        
        public bool IsActive 
            => UnityEngine.Input.touchCount > 0;
        
        public Vector2 ShootDirection 
            => UnityEngine.Input.touchCount == 0 
               ? Vector2.zero 
               : _shootDirectionCalculator.CalculateDirection(UnityEngine.Input.GetTouch(0).position);
    }
}