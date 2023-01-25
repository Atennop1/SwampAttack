using UnityEngine;

namespace SwampAttack.View.Enemies
{
    public interface IEnemyTransformView
    {
        Transform Transform { get; }
        void PlayAnimation(string key);
    }
}