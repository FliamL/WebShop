using C_MobileProject.ViewModels;

namespace C_MobileProject.Views;

public partial class RegisterPageView : ContentPage
{
	public RegisterPageView(RegisterPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}