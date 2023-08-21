using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/Consumable Type Config")]
    public class ConsumableTypeData : ScriptableObject
    {
        [SerializeField] private GameModel.ConsumableTypes consumableTypes;
        [SerializeField] private string infoDescription;
        [SerializeField] private Sprite icon;
        [SerializeField] private Sprite coinIcon;
        [SerializeField] private Sprite creditIcon;
        public GameModel.ConsumableTypes ConsumableTypes => consumableTypes;
        public string InfoDescription => infoDescription;
    
        public Sprite Icon => icon;
        public Sprite CoinIcon => coinIcon;
        public Sprite CreditIcon => creditIcon;
    }
}
