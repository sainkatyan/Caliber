using TMPro;
using UnityEngine;

public abstract class ValueView<T> : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI currencyValueText;
    
    protected void UpdateValueView(int to)
    {
        currencyValueText.text = to.ToString();
    }
}
