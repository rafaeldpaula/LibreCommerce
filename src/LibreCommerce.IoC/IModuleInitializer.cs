using Microsoft.AspNetCore.Builder;

namespace LibreCommerce.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
