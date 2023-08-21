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

        private void Awake()
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

        private void ShowWindow(string pathPrefab)
        {
            WindowsContainer.CreateWindow<WindowBase>(pathPrefab, foreground);
        }

        private void ShowRevisionWindow()
        {
            ShowWindow(ConsumablesWindow.ConsumablesWindowInject._PathPrefab);
        }
        private void ShowExchangeWindow()
        {
            ShowWindow(ConvertWindow.ConvertWindowInject._PathPrefab);
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
