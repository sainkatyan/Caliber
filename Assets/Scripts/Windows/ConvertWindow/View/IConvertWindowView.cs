using System;

namespace Windows.ConvertWindow.View
{
    public interface IConvertWindowView
    {
        event Action<int> OnConvertCoinToCredit;
        event Action<int> OnCoinValueChangeCheck;
        void UpdateCoinToCreditRate(int value);
        void UpdateCreditConvertCount(int value);
        void CoinValueChangeCheck();
    }
}
