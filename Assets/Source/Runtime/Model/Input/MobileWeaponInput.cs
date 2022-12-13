using UnityEngine;

namespace SwampAttack.Runtime.Model.Input
{
    public class MobileWeaponInput : MonoBehaviour, IWeaponInput
    {
        public bool IsActive => UnityEngine.Input.touchCount > 0;
        public Vector2 TouchPosition => UnityEngine.Input.touchCount == 0 ? Vector2.zero : UnityEngine.Input.GetTouch(0).position;
    }
}