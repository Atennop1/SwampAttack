using UnityEngine;

namespace SwampAttack.Runtime.Model.Input
{
    public sealed class PCWeaponInput : MonoBehaviour, IWeaponInput
    {
        public bool IsActive => UnityEngine.Input.GetKeyDown(KeyCode.Mouse0);
        public Vector2 TouchPosition 
        {
            get
            {
                if (IsActive)
                    return UnityEngine.Input.mousePosition;

                return Vector2.zero;
            }
        }
    }
}