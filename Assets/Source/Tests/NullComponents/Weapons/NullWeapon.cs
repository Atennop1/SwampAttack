using SwampAttack.Model.Weapons;
using UnityEngine;

namespace SwampAttack.NullComponents
{
    public class NullWeapon : IWeapon
    {
        public int MaxBullets { get; }
        public int Bullets { get; }
        
        public bool CanShoot => true;
        public bool IsFull => false;
        
        public void Shoot(Vector2 direction) { }
        public void AddBullets(int count) { }
        public void VisualizeBullets() { }
    }
}