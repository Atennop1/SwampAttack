using System;
using SwampAttack.Runtime.Model.Shop.Products;
using SwampAttack.Runtime.Model.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace SwampAttack.Runtime.View.Weapons.PlayerWeapons
{
    public class PlayerWeaponSlotView : MonoBehaviour, IPlayerWeaponSlotView
    {
        [SerializeField] private Image _photo;
        [SerializeField] private Text _nameText;
        [field: SerializeField] public Button UsingButton { get; private set; }

        public void Init(IProduct<IWeapon> product)
        {
            if (product == null)
                throw new ArgumentException("Product can't be null");

            _photo.sprite = product.Data.Sprite;
            _nameText.text = product.Data.Name;
        }
    }
}