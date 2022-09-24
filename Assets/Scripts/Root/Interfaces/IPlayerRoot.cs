using SwampAttack.Input;
using SwampAttack.Weapons;
using SwampAttack.HealthSystem;

namespace SwampAttack.Root
{
    public interface IPlayerRoot
    {
        void Compose((IWeaponInput, IWeapon) weapon);
    }
}
