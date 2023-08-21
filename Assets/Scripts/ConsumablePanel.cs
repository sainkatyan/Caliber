using System;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsumablePanel : MonoBehaviour
{
    [SerializeField] private ConsumableTypeData consumableTypeData;
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Image priceIcon;

    private void Start()
    {
        GetView();
    }

    private void GetView()
    {
        SetIcon(iconImage, consumableTypeData.Icon);
        descriptionText.text = consumableTypeData.InfoDescription;
        priceText.text = GetPriceWithIcon().ToString();
    }

    private int GetPriceWithIcon()
    {
        GameModel.ConsumableConfig value;
        var hasValue = (GameModel.ConsumablesPrice.TryGetValue(consumableTypeData.ConsumableTypes, out value));
        if (!hasValue) return 0;
        
        if (value.CreditPrice != 0)
        {
            SetIcon(priceIcon, consumableTypeData.CreditIcon);
            return value.CreditPrice;
        }
        
        SetIcon(priceIcon, consumableTypeData.CoinIcon);
        return value.CoinPrice;
    }

    private void SetIcon(Image image, Sprite sprite)
    {
        image.sprite = sprite;
    }
}
