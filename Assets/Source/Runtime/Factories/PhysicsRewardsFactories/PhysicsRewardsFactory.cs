using System;
using Sirenix.OdinInspector;
using SwampAttack.Model.Rewards;
using SwampAttack.Model.Wallet;
using SwampAttack.View.Reward;
using UnityEngine;

namespace SwampAttack.Factories
{
    public class PhysicsRewardsFactory : SerializedMonoBehaviour, IPhysicsRewardsFactory
    {
        [SerializeField] private GameObject _physicsRewardPrefab;
        [SerializeField] private RewardDataSO _rewardDataSO;
        
        private readonly RewardRandomizer _rewardRandomizer = new(new HundredPercentChance());
        private IWallet _wallet;

        public IPhysicsReward Create(Vector3 position)
        {
            IReward reward = new Reward(_wallet, new RewardData(_rewardDataSO.Icon, _rewardDataSO.CoinsCount));
            reward = _rewardRandomizer.NullOrDefault(reward);
            
            var physicsRewardGameObject = Instantiate(_physicsRewardPrefab, position, Quaternion.identity, transform);
            var physicsReward = physicsRewardGameObject.GetComponent<IPhysicsReward>();
            
            physicsReward.Init(reward);
            return physicsReward;
        }

        public void Init(IWallet wallet)
            => _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));

        private void Awake()
        {
            if (!_physicsRewardPrefab.TryGetComponent(out IPhysicsReward _))
                throw new ArgumentException("PhysicsRewardPrefab doesn't contains IPhysicsReward component");
        }
    }
}