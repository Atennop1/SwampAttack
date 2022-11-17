using SwampAttack.Runtime.HealthSystem;
using UnityEngine;

namespace SwampAttack.Runtime.Attacks
{
    public interface IAttack
    {
        int Damage { get; }
        void Collide(Collider2D coll);
        bool IsCollisionWithHealth(Collider2D coll, out HealthTransformView healthView);
    }
}