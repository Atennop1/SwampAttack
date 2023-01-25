using SwampAttack.Model.Weapons;
using SwampAttack.View.Health;
using UnityEngine;

namespace SwampAttack.Tests.NullComponents
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