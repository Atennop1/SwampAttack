using UnityEngine;

namespace SwampAttack.Model.Input
{
    public interface IShootDirectionCalculator
    {
        Vector2 CalculateDirection(Vector2 touchPosition);
    }
}