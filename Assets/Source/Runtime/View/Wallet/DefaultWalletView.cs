using SwampAttack.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace SwampAttack.View.Wallet
{
    public class DefaultWalletView : MonoBehaviour, IWalletView
    {
        [SerializeField] private Text _moneyText;
        
        public void Visualize(int money)
            => _moneyText.text = money.TryThrowIfLessThanZero().ToString();
    }
}