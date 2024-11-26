using C_MobileProject.ViewModels;

namespace C_MobileProject.Views;

public partial class CategoriePageView : ContentPage
{
	public CategoriePageView(CategoriePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}