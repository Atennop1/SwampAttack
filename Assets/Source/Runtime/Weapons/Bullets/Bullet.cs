using SwampAttack.Runtime.Attacks;
using SwampAttack.Runtime.HealthSystem;
using UnityEngine;

namespace SwampAttack.Runtime.Weapons.Bullets
{
    public sealed class Bullet : IBullet
    {
        private readonly int _throwForce;
        private readonly Rigidbody2D _rigidbody;
        
        private readonly IAttack _attack;
        public int Damage => _attack.Damage;
        
        public Bullet(IAttack attack, Rigidbody2D rigidbody, int throwForce)
        {
            _rigidbody = rigidbody;
            _throwForce = throwForce;
            _attack = attack;
        }

        public void Launch() => _rigidbody.AddForce(-_rigidbody.transform.right * _throwForce);
        public void Collide(Collider2D coll) => _attack.Collide(coll);
        public bool IsCollisionWithHealth(Collider2D coll, out HealthTransformView healthView) => _attack.IsCollisionWithHealth(coll, out healthView);
    }
}