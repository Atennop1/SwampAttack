using System;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Input
{
    public class UniversalWeaponInput : IWeaponInput
    {
        private readonly IWeaponInput _mobileInput;
        private readonly IWeaponInput _pcInput;

        public UniversalWeaponInput(IWeaponInput mobileInput, IWeaponInput pcInput)
        {
            _mobileInput = mobileInput ?? throw new ArgumentNullException(nameof(mobileInput));
            _pcInput = pcInput ?? throw new ArgumentNullException(nameof(pcInput));
        }

        public bool IsActive 
            => _mobileInput.IsActive || _pcInput.IsActive;

        public Vector2 ShootDirection
        {
            get
            {
                if (_mobileInput.IsActive)
                    return _mobileInput.ShootDirection;

                return _pcInput.IsActive ? _pcInput.ShootDirection : Vector2.zero;
            }
        }
    }
}