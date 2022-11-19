using UnityEngine;

namespace SwampAttack.Runtime.View.Attacks
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BulletTransformView : AttackTransformView
    {
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (_attack.IsCollisionWithHealth(coll, out _))
                _attack.Collide(coll);
            
            Destroy(gameObject);
        }
    }
}