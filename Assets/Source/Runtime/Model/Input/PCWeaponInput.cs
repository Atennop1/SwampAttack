using System;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Input
{
    public sealed class PCWeaponInput : IWeaponInput
    {
        private readonly IShootDirectionCalculator _shootDirectionCalculator;

        public PCWeaponInput(IShootDirectionCalculator shootDirectionCalculator)
            => _shootDirectionCalculator = shootDirectionCalculator ?? throw new ArgumentNullException(nameof(shootDirectionCalculator));

        public bool IsActive 
            => UnityEngine.Input.GetKeyDown(KeyCode.Mouse0);
        
        public Vector2 ShootDirection 
            => IsActive 
               ? _shootDirectionCalculator.CalculateDirection(UnityEngine.Input.mousePosition) 
               : Vector2.zero;
    }
}