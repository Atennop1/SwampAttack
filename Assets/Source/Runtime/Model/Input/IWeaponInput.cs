using UnityEngine;

namespace SwampAttack.Runtime.Model.Input
{
    public interface IWeaponInput
    {
        bool IsActive { get; }
        Vector2 TouchPosition { get; }
    }
}