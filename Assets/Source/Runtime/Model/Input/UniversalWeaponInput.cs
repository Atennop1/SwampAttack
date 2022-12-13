using Sirenix.OdinInspector;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Input
{
    public class UniversalWeaponInput : SerializedMonoBehaviour, IWeaponInput
    {
        [SerializeField] private IWeaponInput _mobileInput;
        [SerializeField] private IWeaponInput _pcInput;

        public bool IsActive => _mobileInput.IsActive || _pcInput.IsActive;

        public Vector2 TouchPosition
        {
            get
            {
                if (_mobileInput.IsActive)
                    return _mobileInput.TouchPosition;

                return _pcInput.IsActive ? _pcInput.TouchPosition : Vector2.zero;
            }
        }
    }
}