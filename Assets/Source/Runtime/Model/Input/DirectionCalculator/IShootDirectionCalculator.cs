using UnityEngine;

namespace SwampAttack.Runtime.Model.Input
{
    public interface IShootDirectionCalculator
    {
        Vector2 CalculateDirection(Vector2 touchPosition);
    }
}