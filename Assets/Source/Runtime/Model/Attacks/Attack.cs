using System;
using SwampAttack.Runtime.View.Health;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Attacks
{
    public sealed class Attack : IAttack
    {
        public int Damage { get; }
        
        public Attack(int damage)
        {
            Damage = damage;
        }
        
        public void Collide(Collider2D coll)
        {
            if (!IsCollisionWithHealth(coll, out var healthView))
                throw new Exception("Collision doesn't contains a health component");

            healthView.TakeDamage(Damage);
        }

        public bool IsCollisionWithHealth(Collider2D coll, out HealthTransformView healthView)
        {
            return coll.gameObject.TryGetComponent(out healthView) &&
                   healthView.CanTakeDamage && !healthView.IsDead;
        }
    }
}