using SwampAttack.Runtime.Model.Attacks;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Weapons.Bullets
{
    public interface IBullet : IAttack
    {
        void Launch(Vector2 direction);
    }
}