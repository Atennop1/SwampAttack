using System;
using UnityEngine;

namespace SwampAttack.Runtime.Model.AI.Enemies.Movement
{
    public class DefaultEnemyMovement : IEnemyMovement
    {
        private readonly Rigidbody2D _rigidbody;
        private float _speed;

        public DefaultEnemyMovement(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Transform target)
        {
            var difference = (target.position - _rigidbody.transform.position).normalized;
            _rigidbody.MovePosition(_rigidbody.transform.position + difference * (Time.deltaTime * _speed));
        }

        public void StopMovement()
        {
            _rigidbody.velocity = Vector2.zero;
        }

        public void ChangeSpeed(float speed)
        {
            if (speed < 0)
                throw new ArgumentException("Can't change speed to negative number");

            _speed = speed;
        }
    }
}