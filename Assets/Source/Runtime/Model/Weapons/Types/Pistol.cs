using SwampAttack.Runtime.Factories;
using SwampAttack.Runtime.Model.Weapons.Bullets;
using SwampAttack.Runtime.View.Weapons;

namespace SwampAttack.Runtime.Model.Weapons.Types
{
    public class Pistol : Weapon
    {
        public Pistol(IFactory<IBullet> factory, IWeaponBulletsView bulletsView, int bullets) 
            : base(factory, bulletsView, bullets) { }
    }
}