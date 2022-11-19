using System;
using SwampAttack.Runtime.Factories;
using SwampAttack.Runtime.Model.Weapons.Bullets;
using SwampAttack.Runtime.View.Weapons;

namespace SwampAttack.Runtime.Model.Weapons
{
    public sealed class Weapon : IWeapon
    {
        public int MaxBullets { get; }
        public int Bullets { get; private set; }
        
        public bool CanShoot => Bullets > 0;

        private readonly IFactory<IBullet> _factory;
        private readonly IWeaponBulletsView _bulletsView;

        public Weapon(IFactory<IBullet> factory, IWeaponBulletsView bulletsView, int bullets)
        {
            if (bullets <= 0)
                throw new ArgumentException($"Can't create weapon with {bullets} bullets");
                
            Bullets = MaxBullets = bullets;
            _bulletsView = bulletsView ?? throw new ArgumentException("BulletsView can't be null");
            _factory = factory ?? throw new ArgumentException("Factory can't be null");
        }

        public void Shoot()
        {
            if (!CanShoot)
                throw new ArgumentException("Can't shoot");

            Bullets--;
            _factory.Create();
            _bulletsView.Visualize(this);
        }

        public void AddBullets(int count)
        {
            if (count < 0)
                throw new ArgumentException($"Can't add {count} bullets");

            Bullets += count;
            _bulletsView.Visualize(this);
        }
    }
}