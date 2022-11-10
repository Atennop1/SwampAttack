using UnityEngine;

namespace SwampAttack.AI.Enemies.Interfaces
{
    public interface IEnemyTransformView
    {
        Transform Transform { get; }
        void PlayAnimation(string key);
    }
}