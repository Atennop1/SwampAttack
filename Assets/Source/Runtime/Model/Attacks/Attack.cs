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
            if (!IsCollisionWithHealth(coll, out var healthTransformView))
                throw new Exception("Collision doesn't contains a HealthTransformView component");

            if (!healthTransformView.CanTakeDamage)
                throw new Exception("Can't take damage to this HealthTransformView");

            if (healthTransformView.IsDead)
                throw new Exception("Can;t take damage to dead HealthTransformView");

            healthTransformView.TakeDamage(Damage);
        }

        public bool IsCollisionWithHealth(Collider2D coll, out IHealthTransformView healthTransformView)
        {
            return coll.gameObject.TryGetComponent(out healthTransformView);
        }
    }
}