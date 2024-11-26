using C_MobileProject.ViewModels;

namespace C_MobileProject.Views;

public partial class ShoppingCartPageView : ContentPage
{
	public ShoppingCartPageView(ShoppingCartViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}