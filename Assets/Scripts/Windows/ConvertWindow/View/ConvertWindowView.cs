using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.ConvertWindow.View
{
    public class ConvertWindowView : MonoBehaviour, IConvertWindowView
    {
        [SerializeField] private TMP_InputField coinConvertInputField;
        [SerializeField] private TMP_Text coinToCreditRateView;
        [SerializeField] private TMP_Text creditConvertCount;
        [SerializeField] private Button convertButton;

        public event Action<int> OnConvertCoinToCredit;
        public event Action<int> OnCoinValueChangeCheck;

        private void Awake()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            convertButton.onClick.AddListener(TryConvertCoinToCredit);
            coinConvertInputField.onValueChanged.AddListener(delegate{CoinValueChangeCheck();});
        }

        public void UpdateCoinToCreditRate(int value)
        {
            coinToCreditRateView.text = value.ToString();
        }
    
        public void UpdateCreditConvertCount(int value)
        {
            creditConvertCount.text = value.ToString();
        }

        private void TryConvertCoinToCredit()
        {
            if (!CanParseFromInputFiled(coinConvertInputField, out int value)) return;
            OnConvertCoinToCredit?.Invoke(value);
        }

        public void CoinValueChangeCheck()
        {
            if (CanParseFromInputFiled(coinConvertInputField, out int num))
            {
                OnCoinValueChangeCheck?.Invoke(num);
                return;
            }
            OnCoinValueChangeCheck?.Invoke(0);
        }
    
        private bool CanParseFromInputFiled(TMP_InputField inputField, out int inputValue)
        {
            return int.TryParse(inputField.text, out inputValue);
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    
        private void Unsubscribe()
        {
            convertButton.onClick.RemoveListener(TryConvertCoinToCredit);
            coinConvertInputField.onValueChanged.RemoveListener(delegate{CoinValueChangeCheck();});
        }
    }
}
