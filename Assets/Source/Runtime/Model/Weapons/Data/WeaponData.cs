using Sirenix.OdinInspector;
using SwampAttack.Runtime.Factories;
using SwampAttack.Runtime.Model.Weapons.Bullets;
using SwampAttack.Runtime.View.Weapons;
using UnityEngine;

namespace SwampAttack.Runtime.Model.Weapons.Data
{
    public class WeaponData : SerializedMonoBehaviour
    {
        [field: SerializeField] public  WeaponType Type { get; private set; }
        [field: SerializeField, MinValue(1)] public int Bullets { get; private set; }
        
        [field: SerializeField, Space] public IFactory<IBullet> BulletsFactory { get; private set; }
        [field: SerializeField] public IWeaponBulletsView BulletsView { get; private set; }
    }
}