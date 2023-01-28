using System;
using SwampAttack.Model.Input;
using SwampAttack.Model.Rewards;
using UnityEngine;

namespace SwampAttack.View.Reward
{
    public class PhysicsReward : MonoBehaviour, IPhysicsReward, IRaycastHittable
    {
        [field: SerializeField] public Collider2D Collider { get; private set; }
        
        private IReward _reward;

        public void Init(IReward reward)
            => _reward = reward ?? throw new ArgumentNullException(nameof(reward));
        
        public void Hit()
        {
            Debug.Log("Collected!");
        }
    }
}