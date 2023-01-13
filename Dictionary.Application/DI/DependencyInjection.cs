using Dictionary.Application.DTOs;
using Dictionary.Application.Handlers;
using Dictionary.Application.Interfaces.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Dictionary.Infra.DI;

public static class DependencyInjection
{
  public static IServiceCollection ImplementHandlers(this IServiceCollection services)
  {
    services.AddScoped<IUserSignUpHandler, UserSignUpHandler>();
    services.AddScoped<IUserSignInHandler, UserSignInHandler>();
    services.AddScoped<IEntriesGetListHandler, EntriesGetListHandler>();

    return services;
  }
}