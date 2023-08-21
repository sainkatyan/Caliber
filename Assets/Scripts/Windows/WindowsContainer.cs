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
    }
}
