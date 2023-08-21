using Windows.ConsumablesWindow.View;

public interface IConsumablesWindowPresenter
{
  IConsumablesWindowPresenter InjectView(ConsumablesWindowView consumablesWindowView);
  void Init();
  void UnsubcribeToView();
}
