using SwampAttack.Runtime.Model.Weapons.Bullets;
using SwampAttack.Runtime.View.Health;
using SwampAttack.Tests.NullComponents.Health;
using UnityEngine;

namespace SwampAttack.Tests.NullComponents.Weapons
{
    public class NullBullet : IBullet
    {
        public int Damage => 0;
        
        public void Collide(Collider2D coll) { }
        public void Launch(Vector2 direction)  { }

        public bool IsCollisionWithHealth(Collider2D coll, out IHealthTransformView healthTransformView)
        {
            healthTransformView = new NullHealthTransformView();
            return true;
        }
    }
}