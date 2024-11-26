using C_MobileProject.ViewModels;

namespace C_MobileProject.Views;

public partial class HomePageView : ContentPage
{

    public HomePageView(HomePageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await (BindingContext as HomePageViewModel).LoadData();
    }
}