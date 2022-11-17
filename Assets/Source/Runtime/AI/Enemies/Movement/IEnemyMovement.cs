using UnityEngine;

namespace SwampAttack.Runtime.AI.Enemies.Movement
{
    public interface IEnemyMovement
    {
        void Move(Transform target);
        void StopMovement();
    }
}