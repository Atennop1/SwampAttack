using SwampAttack.Runtime.Attacks;

namespace SwampAttack.Runtime.Weapons.Bullets
{
    public interface IBullet : IAttack
    {
        void Launch();
    }
}