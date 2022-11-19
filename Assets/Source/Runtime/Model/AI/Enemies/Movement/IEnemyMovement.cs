using UnityEngine;

namespace SwampAttack.Runtime.Model.AI.Enemies.Movement
{
    public interface IEnemyMovement
    {
        void Move(Transform target);
        void StopMovement();
    }
}