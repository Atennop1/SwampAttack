using SwampAttack.Model.Attacks;
using UnityEngine;

namespace SwampAttack.Model.Weapons
{
    public interface IBullet : IAttack
    {
        void Launch(Vector2 direction);
    }
}