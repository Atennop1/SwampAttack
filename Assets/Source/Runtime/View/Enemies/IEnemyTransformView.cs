using UnityEngine;

namespace SwampAttack.Runtime.View.Enemies
{
    public interface IEnemyTransformView
    {
        Transform Transform { get; }
        void PlayAnimation(string key);
    }
}