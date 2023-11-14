using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    [RequireComponent(typeof(CanvasGroup))]
    public class WindowBase : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        public virtual void Initialize()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.interactable = true;
        }
        public virtual void Close()
        {
            if (gameObject == null) return;
            canvasGroup.interactable = false;
            WindowsContainer.HideWindow(this);
        }
    }
}
