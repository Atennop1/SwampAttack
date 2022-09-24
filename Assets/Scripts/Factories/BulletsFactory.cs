using UnityEngine;
using SwampAttack.Weapons.Bullets;

namespace SwampAttack.Factories
{
    public sealed class BulletsFactory : MonoBehaviour, IFactory<IBullet>
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPoint;

        public IBullet Create()
        {
            GameObject bulletObject = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint);
            IBullet bullet =  bulletObject.GetComponent<IBullet>();

            bullet.Laucnh();
            return bullet;
        }
    }
}