using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.View.Weapons;

namespace SwampAttack.Tests.NullComponents.Inventory
{
    public class NullWeaponBulletsView : IWeaponBulletsView
    {
        public void Visualize(IWeapon weapon) { }
    }
}