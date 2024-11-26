using C_MobileProject.ViewModels;

namespace C_MobileProject.Views;

public partial class LoginPageView : ContentPage
{
    public LoginPageView(LoginPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}