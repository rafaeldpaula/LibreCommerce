using LibreCommerce.Application.Users.CreateUser;
using LibreCommerce.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace LibreCommerce.WebApi.Mappings;

public class CreateUserRequestProfile : Profile
{
    public CreateUserRequestProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
    }
}