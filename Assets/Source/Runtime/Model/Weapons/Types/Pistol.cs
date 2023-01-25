using SwampAttack.Factories;
using SwampAttack.View.Weapons;

namespace SwampAttack.Model.Weapons
{
    public class Pistol : Weapon
    {
        public Pistol(IFactory<IBullet> factory, IWeaponBulletsView bulletsView, int bullets) 
            : base(factory, bulletsView, bullets) { }
    }
}