using UnityEngine;

namespace SwampAttack.AI.Enemies.Movement
{
    public interface IEnemyMovement
    {
        void Move(Transform target);
        void StopMovement();
    }
}