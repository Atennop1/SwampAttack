using System;
using SwampAttack.Attacks;
using UnityEngine;
using SwampAttack.Weapons.Bullets;

namespace SwampAttack.Factories
{
    public sealed class BulletsFactory : MonoBehaviour, IFactory<IBullet>
    {
        [SerializeField] private int _throwForce;
        [SerializeField] private int _damage;
        
        [Space]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPoint;

        public IBullet Create()
        {
            var bulletObject = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint);
            var bulletView = bulletObject.GetComponent<AttackTransformView>();
            
            if (bulletView == null)
                throw new ArgumentException($"{_bulletPrefab.name} doesn't BulletView!");

            IBullet bullet = new Bullet( new Attack(1), bulletObject.GetComponent<Rigidbody2D>(), _throwForce);
            bulletView.Init(bullet);

            bullet.Launch();
            return bullet;
        }
    }
}