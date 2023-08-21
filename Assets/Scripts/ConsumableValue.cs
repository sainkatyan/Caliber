using UnityEngine;

public class ConsumableValue : ValueView<GameModel.ConsumableTypes>
{
    [SerializeField] private GameModel.ConsumableTypes consumableType = GameModel.ConsumableTypes.None;
    
    private void OnEnable()
    {
        UpdateConsumableTypeValue();
        Subscribe();
    }

    private void Subscribe()
    {
        GameModel.ModelChanged += UpdateConsumableTypeValue;
    }

    private void UpdateConsumableTypeValue()
    {
        switch (consumableType)   
        {
            case GameModel.ConsumableTypes.Medpack:
                UpdateValueView(GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack));
                break;
            case GameModel.ConsumableTypes.ArmorPlate:
                UpdateValueView(GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate));
                break;
            case GameModel.ConsumableTypes.None:
                UpdateValueView(0);
                break;
        }
    }
    
    private void OnDestroy()
    {
        Unsubscribe();
    }
    
    private void Unsubscribe()
    {
        GameModel.ModelChanged -= UpdateConsumableTypeValue;
    }
}
