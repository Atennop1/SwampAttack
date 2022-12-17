using SwampAttack.Runtime.Factories;
using SwampAttack.Runtime.Model.Weapons.Bullets;
using SwampAttack.Tests.NullComponents.Weapons;

namespace SwampAttack.Tests.NullComponents.Inventory
{
    public class NullBulletsFactory : IFactory<IBullet>
    {
        public IBullet Create() => new NullBullet();
    }
}