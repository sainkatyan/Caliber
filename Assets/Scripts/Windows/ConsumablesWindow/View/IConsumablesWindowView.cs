using System;

namespace Windows.ConsumablesWindow.View
{
    public interface IConsumablesWindowView 
    {
        event Action OnBuyMedpackClicked;
        event Action OnBuyArmorClicked;
    }
}
