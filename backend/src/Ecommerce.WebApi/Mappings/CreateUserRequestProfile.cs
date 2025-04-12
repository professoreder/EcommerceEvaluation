using Ecommerce.Application.Users.CreateUser;
using Ecommerce.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ecommerce.WebApi.Mappings;

public class CreateUserRequestProfile : Profile
{
    public CreateUserRequestProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
    }
}