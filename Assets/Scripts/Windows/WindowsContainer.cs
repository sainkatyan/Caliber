using UnityEngine;

namespace Windows
{
    public class WindowsContainer : MonoBehaviour
    {
        public static T CreateWindow<T>(string pathPrefab, RectTransform parent) where T: WindowBase
        {
            var prefab = Resources.Load<T>(pathPrefab);
            var createWindow = Instantiate(prefab, parent);
            createWindow.Initialize();
            return createWindow;
        }
        
        public static void ShowWindow(WindowBase windowBase)
        {
            windowBase.gameObject.SetActive(true);
            windowBase.Initialize();
        }
        
        public static void HideWindow(WindowBase windowBase)
        {
            windowBase.gameObject.SetActive(false);
        }
    }
}
