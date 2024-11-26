using C_MobileProject.Views;

namespace C_MobileProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePageView), typeof(HomePageView));
            Routing.RegisterRoute(nameof(CategoriePageView), typeof(CategoriePageView));
        }
    }
}
