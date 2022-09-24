using UnityEngine;

namespace SwampAttack.Input
{
    public sealed class PCWeaponInput : MonoBehaviour, IWeaponInput
    {
        public bool IsActive => UnityEngine.Input.GetKeyDown(KeyCode.Mouse0);
    }
}