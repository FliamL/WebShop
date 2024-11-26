using C_MobileProject.Models;
using C_MobileProject.Services.Interfaces;
using C_MobileProject.Services.Repositories;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace C_MobileProject.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        private ObservableCollection<Game> _games;
        private readonly IGameRepository _gameRepository;
        private readonly ITokenService _tokenService;

        public HomePageViewModel(INavigationService navigationService, IGameRepository gameRepository, ITokenService tokenService) : base(navigationService)
        {
            Games = new ObservableCollection<Game>();
            _gameRepository = gameRepository;
            _tokenService = tokenService;
        }

        [RelayCommand]
        private async Task AddToShoppingCart(Game game)
        {
            if (game != null)
            {
                var token = await _tokenService.GetTokenAsync();
                
            }
        }

        public async Task LoadData()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return;
            var token = await _tokenService.GetTokenAsync();
            Games = new ObservableCollection<Game>(await _gameRepository.GetAllGames(token));
        }


        public ObservableCollection<Game> Games
        {
            get => _games;
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }
    }
}
