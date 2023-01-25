using SwampAttack.Factories;
using SwampAttack.Model.Weapons;

namespace SwampAttack.NullComponents
{
    public class NullBulletsFactory : IFactory<IBullet>
    {
        public IBullet Create() 
            => new NullBullet();
    }
}