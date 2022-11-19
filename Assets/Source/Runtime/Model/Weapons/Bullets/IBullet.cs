using SwampAttack.Runtime.Model.Attacks;

namespace SwampAttack.Runtime.Model.Weapons.Bullets
{
    public interface IBullet : IAttack
    {
        void Launch();
    }
}