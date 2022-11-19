using SwampAttack.Runtime.View.Health;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Attacks
{
    public interface IAttack
    {
        int Damage { get; }
        void Collide(Collider2D coll);
        bool IsCollisionWithHealth(Collider2D coll, out HealthTransformView healthView);
    }
}