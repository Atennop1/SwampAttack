using UnityEngine;

namespace SwampAttack.Model.Rewards
{
    [CreateAssetMenu(menuName = "Reward Data", fileName = "Reward Data")]
    public class RewardDataSO : ScriptableObject
    {
        [field: SerializeField] public int CoinsCount { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}