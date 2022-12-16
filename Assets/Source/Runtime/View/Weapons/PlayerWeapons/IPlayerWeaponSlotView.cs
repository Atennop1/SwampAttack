using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using UnityEngine.UI;

namespace SwampAttack.Runtime.View.Weapons.PlayerWeapons
{
    public interface IPlayerWeaponSlotView
    {
        Button UsingButton { get; }
        void Init(IProduct<IWeapon> product);
    }
}