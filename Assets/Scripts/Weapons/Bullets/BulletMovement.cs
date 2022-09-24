using UnityEngine;

namespace SwampAttack.Weapons.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BulletMovement : MonoBehaviour, IBullet
    {
        [SerializeField, Min(1)] private int _throwForce;

        private Rigidbody2D _rigidbody;
        
        private void OnEnable() => _rigidbody = GetComponent<Rigidbody2D>();

        public void Laucnh()
        {
            _rigidbody.AddForce(Vector3.forward * _throwForce);
        }
    }
}