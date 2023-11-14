using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class MainMenuWindow : WindowBase
    {
        [SerializeField] private RectTransform foreground;
        [SerializeField] private Button medpackButton;
        [SerializeField] private Button armorButton;
        [SerializeField] private Button exchangeButton;

        [Space]
        [SerializeField] private WindowBase consumableWindow;
        [SerializeField] private WindowBase convertWindow;

        private void Start()
        {
            Initialize();
        }
        public override void Initialize()
        {
            base.Initialize();
            Subscribe();
        }

        private void Subscribe()
        {
            exchangeButton.onClick.AddListener(ShowExchangeWindow);
            medpackButton.onClick.AddListener(ShowRevisionWindow);
            armorButton.onClick.AddListener(ShowRevisionWindow);
        }
        
        private void CreateWindow(string pathPrefab)
        {
            WindowsContainer.CreateWindow<WindowBase>(pathPrefab, foreground);
        }

        private void ShowWindow(WindowBase windowBase)
        {
            WindowsContainer.ShowWindow(windowBase);
        }

        private void ShowRevisionWindow()
        {
            ShowWindow(consumableWindow);
        }
        private void ShowExchangeWindow()
        {
            ShowWindow(convertWindow);
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            exchangeButton.onClick.RemoveListener(ShowExchangeWindow);
            medpackButton.onClick.RemoveListener(ShowRevisionWindow);
            armorButton.onClick.RemoveListener(ShowRevisionWindow);
        }
    }
}
