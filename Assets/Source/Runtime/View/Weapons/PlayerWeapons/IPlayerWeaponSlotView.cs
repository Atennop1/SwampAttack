using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;

namespace SwampAttack.Runtime.View.Weapons.PlayerWeapons
{
    public interface IPlayerWeaponSlotView
    {
        void Init(IProduct<IWeapon> product);
    }
}