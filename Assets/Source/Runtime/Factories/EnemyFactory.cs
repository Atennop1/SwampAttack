using Sirenix.OdinInspector;
using SwampAttack.Runtime.Root;
using UnityEngine;

namespace SwampAttack.Runtime.Factories
{
    public sealed class EnemyFactory : SerializedMonoBehaviour, IFactory<EnemyRoot>
    {
        [SerializeField] private EnemyRoot _enemyPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _target;
        
        public EnemyRoot Create()
        {
            if (Application.isEditor && !Application.isPlaying)
                return null;

            var createdEnemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint);
            createdEnemy.Init(_target);
            
            createdEnemy.Compose();
            return createdEnemy;
        }
    }
}