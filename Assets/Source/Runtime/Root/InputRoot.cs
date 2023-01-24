using Sirenix.OdinInspector;
using SwampAttack.Runtime.Model.Input;
using UnityEngine;

namespace SwampAttack.Runtime.Root
{
    public class InputRoot : SerializedMonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _gunEndPosition;
        
        public IWeaponInput Compose()
        {
            var shootDirectionCalculator = new ShootDirectionCalculator(_camera, _gunEndPosition);
            var mobileInput = new MobileWeaponInput(shootDirectionCalculator);
            var pcInput = new PCWeaponInput(shootDirectionCalculator);
            
            var universalWeaponInput = new UniversalWeaponInput(mobileInput, pcInput);
            return universalWeaponInput;
        }
    }
}