using Windows.ConsumablesWindow.View;
using UnityEditor;
using UnityEngine;

namespace Windows.ConsumablesWindow
{
    public class ConsumablesWindowInject : WindowBase
    {
        public const string _PathPrefab = "Prefabs/Windows/ConsumablesWindow";
        
        [SerializeField] private ConsumablesWindowView consumablesWindowView;
        private IConsumablesWindowPresenter consumablesWindowPresenter = null;
        public override void Initialize()
        {
            base.Initialize();
            Inject();
        }

        private void Inject()
        {
            consumablesWindowPresenter = new ConsumablesWindowPresenter();
            consumablesWindowPresenter.InjectView(consumablesWindowView);
            consumablesWindowPresenter.Init();
        }

        private void Update()
        {
            GameModel.Update();
        }

        private void OnDestroy()
        {
            consumablesWindowPresenter.UnsubcribeToView();
        }
    }
}
