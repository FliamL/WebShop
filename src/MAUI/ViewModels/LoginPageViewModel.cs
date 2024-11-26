using C_MobileProject.Models;
using C_MobileProject.Services.Interfaces;
using C_MobileProject.Services.Repositories;
using C_MobileProject.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;

namespace C_MobileProject.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginPageViewModel(INavigationService navigationService, IUserRepository userRepository, ITokenService tokenService) : base(navigationService)
        {
            _httpClient = new HttpClient();
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        private async Task LoginAsync()
        {
            var user = new UserLogin
            {
                Username = username,
                Password = password
            };

           var token = await _userRepository.DoLogin(user);
            if (token != null || token!.Token != null)
            {
                await _tokenService.SaveTokenAsync(token.Token);
                await NavigationService.NavigateToAsync(nameof(HomePageView));
            }
        }
    }
}
