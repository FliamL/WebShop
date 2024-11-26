using AutoMapper;
using System.IO.Pipelines;
using Webshop.API.Entities;
using Webshop.API.Models;

namespace Webshop.API.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>().ReverseMap();
        }
    }
}
