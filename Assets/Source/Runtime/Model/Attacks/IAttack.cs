using SwampAttack.View.Health;
using UnityEngine;

namespace SwampAttack.Model.Attacks
{
    public interface IAttack
    {
        int Damage { get; }
        void Collide(Collider2D coll);
        bool IsCollisionWithHealth(Collider2D coll, out IHealthTransformView healthTransformView);
    }
}