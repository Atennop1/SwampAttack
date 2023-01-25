using SwampAttack.Model.Shop;
using SwampAttack.Model.Weapons;
using UnityEngine.UI;

namespace SwampAttack.View.Weapons
{
    public interface IPlayerWeaponSlotView
    {
        Button UsingButton { get; }
        void Init(IProduct<IWeapon> product);
    }
}