using System;
using SwampAttack.Tools;
using UnityEngine;

namespace SwampAttack.Model.AI.Enemies
{
    public class DefaultEnemyMovement : IEnemyMovement
    {
        private readonly Rigidbody2D _rigidbody;
        private float _speed;

        public DefaultEnemyMovement(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody ?? throw new ArgumentNullException(nameof(rigidbody));
            _speed = speed.TryThrowIfLessOrEqualsZero();
        }

        public void Move(Transform target)
        {
            var difference = (target.position - _rigidbody.transform.position).normalized;
            _rigidbody.MovePosition(_rigidbody.transform.position + difference * (Time.deltaTime * _speed));
        }

        public void StopMovement()
            =>_rigidbody.velocity = Vector2.zero;

        public void ChangeSpeed(float speed)
            => _speed = speed.TryThrowIfLessOrEqualsZero();
    }
}