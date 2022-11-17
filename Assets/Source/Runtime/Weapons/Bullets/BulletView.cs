using SwampAttack.Runtime.Attacks;
using UnityEngine;

namespace SwampAttack.Runtime.Weapons.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BulletView : AttackTransformView
    {
        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (_attack.IsCollisionWithHealth(coll, out _))
                _attack.Collide(coll);
            
            Destroy(gameObject);
        }
    }
}