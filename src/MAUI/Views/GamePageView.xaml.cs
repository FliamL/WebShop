using C_MobileProject.ViewModels;

namespace C_MobileProject.Views;

public partial class GamePageView : ContentPage
{
	public GamePageView(GamePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}