using UnityEngine;

namespace SwampAttack.Runtime.Input
{
    public sealed class PCWeaponInput : MonoBehaviour, IWeaponInput
    {
        public bool IsActive => UnityEngine.Input.GetKeyDown(KeyCode.Mouse0);
    }
}