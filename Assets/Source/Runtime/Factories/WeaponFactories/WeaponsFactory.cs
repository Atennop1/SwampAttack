using System;
using Sirenix.OdinInspector;
using SwampAttack.Model.Weapons;
using UnityEngine;

namespace SwampAttack.Factories
{
    public class WeaponsFactory : SerializedMonoBehaviour, IWeaponsFactory
    {
        [SerializeField] private WeaponData _pistolData;
        [SerializeField] private WeaponData _shotgunData;
        
        public IWeapon Create(WeaponSavingData savingData)
        {
            return savingData.Type switch
            {
                WeaponType.Pistol => new Pistol(_pistolData.BulletsFactory, _pistolData.BulletsView,  18/*savingData.Bullets*/),
                WeaponType.Shotgun => new Shotgun(_shotgunData.BulletsFactory, _shotgunData.BulletsView, 18/*savingData.Bullets*/),
                _ => throw new Exception("Invalid WeaponType")
            };
        }
    }
}