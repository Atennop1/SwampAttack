using System;
using SwampAttack.Model.Rewards;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SwampAttack.View.Reward
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicsReward : MonoBehaviour, IPhysicsReward
    {
        [SerializeField, Range(50, 200)] private float _throwingForce;
        [SerializeField, Range(50, 200)] private float _spread;
        [field: SerializeField] public Collider2D Collider { get; private set; }

        private Rigidbody2D _rigidbody;
        private IReward _reward;

        public void Init(IReward reward)
            => _reward = reward ?? throw new ArgumentNullException(nameof(reward));

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            var spreadSymbol = Random.Range(0, 2) == 0 ? -1 : 1;
            _rigidbody.AddForce(new Vector2(Random.Range(0f, _spread) * spreadSymbol, _throwingForce));
        }

        public void Hit()
        {
            _reward.Apply();
            Destroy(gameObject);
        }
    }
}