using Windows.ConvertWindow.View;

namespace Windows.ConvertWindow.Presenter
{
    public class ConvertWindowPresenter : IConvertWindowPresenter
    {
        private IConvertWindowView convertWindowView = null;
        private int coinToCredit;

        public IConvertWindowPresenter InjectView(ConvertWindowView view)
        {
            convertWindowView = view;
            SubscribeToView();
            return this;
        }
        
        private void SubscribeToView()
        {
            convertWindowView.OnCoinValueChangeCheck += ValueChangeCheck;
            convertWindowView.OnConvertCoinToCredit += ConvertToCredit;
        }
        
        public void Init()
        {
            coinToCredit = GameModel.CoinToCreditRate;
            UpdateCoinToCreditView();
        }

        private void UpdateCoinToCreditView()
        {
            convertWindowView.UpdateCoinToCreditRate(coinToCredit);
            convertWindowView.CoinValueChangeCheck();
        }

        private void ValueChangeCheck(int value)
        {
            var creditConvertCount = value * coinToCredit;
            convertWindowView.UpdateCreditConvertCount(creditConvertCount);
        }

        private void ConvertToCredit(int value)
        {
            if (GameModel.HasRunningOperations) return;
            GameModel.ConvertCoinToCredit(value);
        }

        public void UnsubscribeToView()
        {
            convertWindowView.OnCoinValueChangeCheck -= ValueChangeCheck;
            convertWindowView.OnConvertCoinToCredit -= ConvertToCredit;
        }
    }
}
