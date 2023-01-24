using SwampAttack.Runtime.View.Weapons;

namespace SwampAttack.Tests.NullComponents.Inventory
{
    public class NullWeaponBulletsView : IWeaponBulletsView
    {
        public void Visualize(int currentBulletsCount, int maxBulletsCount) { }
    }
}