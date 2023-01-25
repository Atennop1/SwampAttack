using UnityEngine;
using UnityEngine.UI;

namespace SwampAttack.View.Weapons
{
    public class DefaultWeaponBulletsView : MonoBehaviour, IWeaponBulletsView
    {
        [SerializeField] private Text _countText;

        public void Visualize(int currentBulletsCount, int maxBulletsCount)
            => _countText.text = $"{currentBulletsCount}/{maxBulletsCount}";
    }
}