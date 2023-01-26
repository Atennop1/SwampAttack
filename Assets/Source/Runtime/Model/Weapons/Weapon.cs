using System;
using SwampAttack.Factories;
using SwampAttack.Tools;
using SwampAttack.View.Weapons;
using UnityEngine;

namespace SwampAttack.Model.Weapons
{
    public class Weapon : IWeapon
    {
        public int MaxBullets { get; }
        public int Bullets { get; private set; }

        public bool CanShoot => Bullets > 0;
        public bool IsFull => Bullets == MaxBullets;

        private readonly IFactory<IBullet> _factory;
        private readonly IWeaponBulletsView _bulletsView;

        public Weapon(IFactory<IBullet> factory, IWeaponBulletsView bulletsView, int bullets)
        {
            _bulletsView = bulletsView ?? throw new ArgumentException("BulletsView can't be null");
            _factory = factory ?? throw new ArgumentException("Factory can't be null");

            Bullets = MaxBullets = bullets.TryThrowIfLessOrEqualsZero();
            bulletsView.Visualize(Bullets, MaxBullets);
        }

        public void Shoot(Vector2 direction)
        {
            if (!CanShoot)
                throw new ArgumentException("Can't shoot");

            Bullets--;
            _factory.Create().Launch(direction);
            _bulletsView.Visualize(Bullets, MaxBullets);
        }

        public void AddBullets(int count)
        {
            if (Bullets + count.TryThrowIfLessThanZero() > MaxBullets)
                throw new ArgumentException("BulletsCount too big");

            Bullets += count;
            _bulletsView.Visualize(Bullets, MaxBullets);
        }
    }
}