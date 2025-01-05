using LibreCommerce.Application.Users.GetUser;
using LibreCommerce.Domain.Entities;
using AutoMapper;

namespace LibreCommerce.Application.Products.GetUser;

public class GetProductCommandProfile : Profile
{
    public GetProductCommandProfile()
    {
        CreateMap<Product, GetProductCommandResult>();
    }
}