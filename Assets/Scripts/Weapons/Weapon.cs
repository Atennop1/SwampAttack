using System;
using SwampAttack.Factories;
using SwampAttack.Weapons.Bullets;

namespace SwampAttack.Weapons
{
    public sealed class Weapon : IWeapon
    {
        public int Bullets { get; private set; }
        public bool CanShoot => Bullets > 0;

        private IFactory<IBullet> _factory;

        public Weapon(IFactory<IBullet> factory, int bullets)
        {
            if (bullets <= 0)
                throw new ArgumentException($"Can't create weapon with {bullets} bullets");
                
            Bullets = bullets;
            _factory = factory;
        }

        public void Shoot()
        {
            if (!CanShoot)
                throw new ArgumentException("Can't shoot");

            _factory.Create();
            Bullets--;
        }

        public void AddBullets(int count)
        {
            if (count < 0)
                throw new ArgumentException($"Can't add {count} bullets");

            Bullets += count;
        }
    }
}