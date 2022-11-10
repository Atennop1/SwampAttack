using SwampAttack.Attacks;

namespace SwampAttack.Weapons.Bullets
{
    public interface IBullet : IAttack
    {
        void Launch();
    }
}