using UnityEngine;

namespace SwampAttack.Runtime.AI.Enemies.Interfaces
{
    public interface IEnemyTransformView
    {
        Transform Transform { get; }
        void PlayAnimation(string key);
    }
}