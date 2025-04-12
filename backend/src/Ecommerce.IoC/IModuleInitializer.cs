using Microsoft.AspNetCore.Builder;

namespace Ecommerce.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
