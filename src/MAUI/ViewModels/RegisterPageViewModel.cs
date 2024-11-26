using C_MobileProject.Models;
using C_MobileProject.Services.Interfaces;
using C_MobileProject.Services.Repositories;
using C_MobileProject.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace C_MobileProject.ViewModels
{
    public partial class RegisterPageViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public RegisterPageViewModel(INavigationService navigationService, IUserRepository userRepository, ITokenService tokenService) : base(navigationService)
        {
            _httpClient = new HttpClient();
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmPassword;

        [ObservableProperty]
        private string country;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string city;

        [RelayCommand]
        private async Task RegisterAsync()
        {
            var user = new User
            {
                Email = username,
                Password = password,
                ConfirmPassword = confirmPassword,
                Country = country,
                Address = address,
                City = city
            };

            var token = await _userRepository.DoRegister(user);

            if (token != null || token!.Token != null)
            {
                await _tokenService.SaveTokenAsync(token.Token);
                await NavigationService.NavigateToAsync(nameof(HomePageView));
            }
        }


    }


}
