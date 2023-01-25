using SwampAttack.Factories;
using SwampAttack.View.Weapons;

namespace SwampAttack.Model.Weapons
{
    public class Shotgun : Weapon
    {
        public Shotgun(IFactory<IBullet> factory, IWeaponBulletsView bulletsView, int bullets) 
            : base(factory, bulletsView, bullets) { }
    }
}