using SwampAttack.Factories;
using SwampAttack.Model.Weapons;

namespace SwampAttack.Tests.NullComponents
{
    public class NullWeaponsFactory : IWeaponsFactory
    {
        public IWeapon Create(WeaponSavingData savingData) 
            => new Pistol(new NullBulletsFactory(), new NullWeaponBulletsView(), 1);
    }
}