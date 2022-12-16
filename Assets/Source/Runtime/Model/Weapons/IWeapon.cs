using UnityEngine;

namespace SwampAttack.Runtime.Model.Weapons
{
    public interface IWeapon
    {
        int MaxBullets { get; }
        int Bullets { get; }
        
        bool CanShoot { get; }
        bool IsFull { get; }

        void Shoot(Vector2 direction);
        void AddBullets(int count);
        void VisualizeBullets();
    }
}