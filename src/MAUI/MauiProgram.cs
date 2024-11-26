using C_MobileProject.Services;
using C_MobileProject.Services.Repositories;
using C_MobileProject.ViewModels;
using C_MobileProject.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using C_MobileProject.Services.Interfaces;

namespace C_MobileProject
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
            builder.Services.AddSingleton<LoginPageView>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<HomePageView>();
            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddSingleton<CategoriePageView>();
            builder.Services.AddSingleton<CategoriePageViewModel>();
            builder.Services.AddSingleton<RegisterPageViewModel>();
            builder.Services.AddSingleton<RegisterPageView>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IGameRepository, GameRepository>();
            builder.Services.AddSingleton<ITokenService, TokenService>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}