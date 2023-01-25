using SwampAttack.View.Weapons;

namespace SwampAttack.Tests.NullComponents
{
    public class NullWeaponBulletsView : IWeaponBulletsView
    {
        public void Visualize(int currentBulletsCount, int maxBulletsCount) { }
    }
}