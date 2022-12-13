using System;
using SwampAttack.Runtime.Model.Attacks;
using SwampAttack.Runtime.Model.Weapons.Bullets;
using SwampAttack.Runtime.View.Attacks;
using UnityEngine;

namespace SwampAttack.Runtime.Factories
{
    public sealed class BulletsFactory : MonoBehaviour, IFactory<IBullet>
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _throwForce;

        [Space]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPoint;

        public IBullet Create()
        {
            var bulletObject = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint);
            var bulletView = bulletObject.GetComponent<AttackTransformView>();
            
            if (bulletView == null)
                throw new ArgumentException($"{_bulletPrefab.name} doesn't BulletView!");

            IBullet bullet = new Bullet(new Attack(_damage), bulletObject.GetComponent<Rigidbody2D>(), _throwForce);
            bulletView.Init(bullet);
            return bullet;
        }
    }
}