using AutoMapper;
using Webshop.API.Entities;
using Webshop.API.Models;

namespace Webshop.API.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
        }
    }
}
