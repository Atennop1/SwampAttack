using UnityEngine;

namespace SwampAttack.Model.Input
{
    public interface IRaycastHittable
    {
        Collider2D Collider { get; }
        void Hit();
    }
}