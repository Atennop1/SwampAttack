using SwampAttack.Runtime.Factories;
using SwampAttack.Runtime.Model.Weapons.Bullets;
using SwampAttack.Runtime.View.Weapons;

namespace SwampAttack.Runtime.Model.Weapons.Types
{
    public class Shotgun : Weapon
    {
        public Shotgun(IFactory<IBullet> factory, IWeaponBulletsView bulletsView, int bullets) 
            : base(factory, bulletsView, bullets) { }
    }
}