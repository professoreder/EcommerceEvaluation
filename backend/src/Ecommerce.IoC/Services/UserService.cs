using Ecommerce.Domain.Services;

namespace Ecommerce.IoC.Services;

public class UserService : IUserService
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
