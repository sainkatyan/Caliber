
using Windows.ConsumablesWindow.View;

public class ConsumablesWindowPresenter : IConsumablesWindowPresenter
{
    private IConsumablesWindowView consumablesWindowView = null;

    public IConsumablesWindowPresenter InjectView(ConsumablesWindowView view)
    {
        consumablesWindowView = view;
        SubcribeToView();
        return this;
    }
    
    private void SubcribeToView()
    {
        consumablesWindowView.OnBuyArmorClicked += BuyArmorButtonClickedHandler;
        consumablesWindowView.OnBuyMedpackClicked += BuyMedpackButtonClickedHandler;
    }

    public void Init()
    {
        InitView();
    }
    
    private void InitView()
    {
        //UpdateConsumablePrices();
    }
    

    private void BuyArmorButtonClickedHandler()
    {
        if (GameModel.HasRunningOperations) return;
        
        GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.ArmorPlate);
    }
    private void BuyMedpackButtonClickedHandler()
    {
        if (GameModel.HasRunningOperations) return;
        
        GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.Medpack);
    }

    public void UnsubcribeToView()
    {
        consumablesWindowView.OnBuyArmorClicked -= BuyArmorButtonClickedHandler;
        consumablesWindowView.OnBuyMedpackClicked -= BuyMedpackButtonClickedHandler;
    }

}
