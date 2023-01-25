using UnityEngine;

namespace SwampAttack.Model.Input
{
    public interface IWeaponInput
    {
        bool IsActive { get; }
        Vector2 ShootDirection { get; }
    }
}