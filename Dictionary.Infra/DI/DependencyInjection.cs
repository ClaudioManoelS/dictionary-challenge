using Dictionary.Infra.Data;
using Dictionary.Infra.Interfaces;
using Dictionary.Infra.Interfaces.Services;
using Dictionary.Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dictionary.Infra.DI;

public static class DependencyInjection
{
  public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration config)
  {

    services.AddDbContext<DictionaryDbContext>(options => options.UseMySql(
          config.GetConnectionString(nameof(DictionaryDbContext)),
          new MySqlServerVersion(new Version(5, 0, 0)),
          mySqlOptions => mySqlOptions
              .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
              .MigrationsAssembly(typeof(DictionaryDbContext).Assembly.FullName)
      ));

    services.AddScoped<IUnitOfWork, UnitOfWork>();

    return services;
  }

  public static IServiceCollection ImplementServices(this IServiceCollection services)
  {
    services.AddScoped<ITokenService, TokenService>();
    services.AddScoped<IHashService, HashService>();

    return services;
  }

}