using UnityEngine;

namespace SwampAttack.Model.AI.Enemies
{
    public interface IEnemyMovement
    {
        void Move(Transform target);
        void StopMovement();
    }
}