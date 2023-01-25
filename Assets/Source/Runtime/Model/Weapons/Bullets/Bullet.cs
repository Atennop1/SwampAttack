using SwampAttack.Model.Attacks;
using SwampAttack.View.Health;
using UnityEngine;

namespace SwampAttack.Model.Weapons
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

        public void Launch(Vector2 direction)
        {
            _rigidbody.AddForce(direction * _throwForce);
            var rotatingQuaternion = Quaternion.LookRotation(Vector3.forward, direction);
            _rigidbody.transform.rotation = rotatingQuaternion;
        }
        
        public void Collide(Collider2D coll) 
            => _attack.Collide(coll);
        
        public bool IsCollisionWithHealth(Collider2D coll, out IHealthTransformView healthTransformView) 
            => _attack.IsCollisionWithHealth(coll, out healthTransformView);
    }
}