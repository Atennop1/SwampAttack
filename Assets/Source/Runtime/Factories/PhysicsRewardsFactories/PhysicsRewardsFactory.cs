using System;
using Sirenix.OdinInspector;
using SwampAttack.Model.Input;
using SwampAttack.Model.Rewards;
using SwampAttack.Model.Wallet;
using SwampAttack.Tools;
using SwampAttack.View.Reward;
using UnityEngine;

namespace SwampAttack.Factories
{
    public class PhysicsRewardsFactory : SerializedMonoBehaviour, IPhysicsRewardsFactory
    {
        [SerializeField] private RewardDataSO _rewardDataSO;
        [SerializeField] private GameObject _physicsRewardPrefab;
        [SerializeField] private IRaycastThrower _raycastThrower;

        private readonly NullRewardRandomizer _nullRewardRandomizer = new(new Randomizer(new HundredPercentChance()));
        private IWallet _wallet;

        public IPhysicsReward Create(Vector3 position)
        {
            IReward reward = new Reward(_wallet, new RewardData(_rewardDataSO.Icon, _rewardDataSO.CoinsCount));
            reward = _nullRewardRandomizer.Randomize(reward);
            
            var physicsRewardGameObject = Instantiate(_physicsRewardPrefab, position + Vector3.up, Quaternion.identity, transform);
            var physicsReward = physicsRewardGameObject.GetComponent<IPhysicsReward>();
            
            physicsReward.Init(reward);
            _raycastThrower.AddHittable(physicsReward);
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