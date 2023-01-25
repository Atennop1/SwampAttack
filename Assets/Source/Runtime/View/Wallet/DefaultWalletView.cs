using TMPro;
using UnityEngine;

namespace SwampAttack.Runtime.View.Wallet
{
    public class DefaultWalletView : MonoBehaviour, IWalletView
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        
        public void Visualize(int money)
            => _moneyText.text = money.ToString();
    }
}