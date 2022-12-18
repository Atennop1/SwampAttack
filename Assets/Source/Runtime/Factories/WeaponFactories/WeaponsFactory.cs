using System;
using Sirenix.OdinInspector;
using SwampAttack.Runtime.Model.Weapons;
using SwampAttack.Runtime.Model.Weapons.Data;
using UnityEngine;

namespace SwampAttack.Runtime.Factories.WeaponFactories
{
    public class WeaponsFactory : SerializedMonoBehaviour, IWeaponsFactory
    {
        [SerializeField] private WeaponData _pistolData;
        [SerializeField] private WeaponData _shotgunData;
        
        public IWeapon Create(WeaponSavingData savingData)
        {
            return savingData.Type switch
            {
                WeaponType.Pistol => new Weapon(_pistolData.BulletsFactory, _pistolData.BulletsView, savingData.Bullets),
                WeaponType.Shotgun => new Weapon(_shotgunData.BulletsFactory, _shotgunData.BulletsView, savingData.Bullets),
                _ => throw new Exception("Invalid WeaponType")
            };
        }
    }
}