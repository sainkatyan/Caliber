using Windows.ConvertWindow.Presenter;
using Windows.ConvertWindow.View;
using UnityEngine;

namespace Windows.ConvertWindow
{
    public class ConvertWindowInject : WindowBase
    {
        public const string _PathPrefab = "Prefabs/Windows/ConvertWindow";
        
        [SerializeField] private ConvertWindowView convertWindowView;
        private IConvertWindowPresenter convertWindowPresenter;
    
        public override void Initialize()
        {
            base.Initialize();
            Inject();
        }
    
        private void Inject()
        {
            convertWindowPresenter = new ConvertWindowPresenter();
            convertWindowPresenter.InjectView(convertWindowView);
            convertWindowPresenter.Init();
        }
    
        private void Update()
        {
            GameModel.Update();
        }

        private void OnDisable()
        {
            convertWindowPresenter.UnsubscribeToView();
        }
    }
}
