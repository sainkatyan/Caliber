using UnityEngine;

public class CurrencyValue : ValueView<CurrencyType>
{
    [SerializeField] private CurrencyType currencyType = CurrencyType.Coin;
    private void OnEnable()
    {
        UpdateCurrencyValue();
        Subscribe();
    }

    private void Subscribe()
    {
        GameModel.ModelChanged += UpdateCurrencyValue;
    }

    private void UpdateCurrencyValue()
    {
        switch (currencyType)   
        {
            case CurrencyType.Coin:
                UpdateValueView(GameModel.CoinCount);
                break;
            case CurrencyType.Credit:
                UpdateValueView(GameModel.CreditCount);
                break;
        }
    }
    
    private void OnDestroy()
    {
        Unsubscribe();
    }
    
    private void Unsubscribe()
    {
        GameModel.ModelChanged -= UpdateCurrencyValue;
    }
}
