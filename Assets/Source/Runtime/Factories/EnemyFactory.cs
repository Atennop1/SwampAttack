using Sirenix.OdinInspector;
using SwampAttack.Model.AI.Enemies;
using SwampAttack.Root;
using UnityEngine;

namespace SwampAttack.Factories
{
    public sealed class EnemyFactory : SerializedMonoBehaviour, IFactory<IEnemy>
    {
        [SerializeField] private IPhysicsRewardsFactory _physicsRewardsFactory;
        [SerializeField] private EnemyRoot _enemyPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _target;
        
        public IEnemy Create()
        {
            if (Application.isEditor && !Application.isPlaying)
                return null;

            var createdEnemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint);
            createdEnemy.Init(_physicsRewardsFactory, _target);
            
            return createdEnemy.Compose();
        }
    }
}