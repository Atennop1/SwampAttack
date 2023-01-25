using SwampAttack.Runtime.Factories.WeaponFactories;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using SwampAttack.Runtime.Model.Weapons.Types;
using SwampAttack.Tests.NullComponents.Inventory;

namespace SwampAttack.Tests.NullComponents.Weapons
{
    public class NullWeaponsFactory : IWeaponsFactory
    {
        public IWeapon Create(WeaponSavingData savingData) 
            => new Pistol(new NullBulletsFactory(), new NullWeaponBulletsView(), 1);
    }
}