using System;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.ConsumablesWindow.View
{
    public class ConsumablesWindowView : MonoBehaviour, IConsumablesWindowView
    {
        public event Action OnBuyMedpackClicked;
        public event Action OnBuyArmorClicked;

        [SerializeField] private Button buyArmorButton;
        [SerializeField] private Button buyMedpacketButton;

        private void Awake()
        {
            buyArmorButton.onClick.AddListener(BuyArmor);
            buyMedpacketButton.onClick.AddListener(BuyMedpack);
        }

        private void BuyArmor()
        {
            OnBuyArmorClicked?.Invoke();
        }

        private void BuyMedpack()
        {
            OnBuyMedpackClicked?.Invoke();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            buyArmorButton.onClick.RemoveListener(BuyArmor);
            buyMedpacketButton.onClick.RemoveListener(BuyMedpack);
        }
    }
}
