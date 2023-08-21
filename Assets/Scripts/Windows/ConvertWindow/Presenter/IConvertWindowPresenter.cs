using Windows.ConvertWindow.View;

namespace Windows.ConvertWindow.Presenter
{
    public interface IConvertWindowPresenter
    {
        IConvertWindowPresenter InjectView(ConvertWindowView convertWindowView);
        void Init();
        void UnsubscribeToView();
    }
}
