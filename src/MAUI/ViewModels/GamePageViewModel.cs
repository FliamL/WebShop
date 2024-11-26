using C_MobileProject.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_MobileProject.ViewModels
{
    public partial class GamePageViewModel : BaseViewModel
    {
        private readonly IGameRepository _gameRepository;
        private readonly HttpClient _httpClient;
        public GamePageViewModel(INavigationService navigationService, IGameRepository gameRepository) : base(navigationService)
        {
            _httpClient = new HttpClient();
            _gameRepository = gameRepository;
        }


    }
}
