using AutoMapper;
using Webshop.API.Entities;
using Webshop.API.Models;

namespace Webshop.API.Profiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, CartItemDto>().ReverseMap();
        }
    }
}
