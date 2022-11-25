using UnityEngine;

namespace SwampAttack.Runtime.View.Attacks
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BulletTransformView : AttackTransformView
    {
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (Attack.IsCollisionWithHealth(coll, out _))
                Attack.Collide(coll);
            
            Destroy(gameObject);
        }
    }
}