using Devsu.Application.Contracts.Infrastructure;
using Devsu.Application.Contracts.Persistence;
using Devsu.Application.Contracts.Persistence.Operaciones;
using Devsu.Application.Models;
using Devsu.Infrastructure.Email;
using Devsu.Infrastructure.Persistence;
using Devsu.Infrastructure.Repositories;
using Devsu.Infrastructure.Repositories.Operaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devsu.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DevsuDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IMovimientosRepository, MovimientosRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }

    }
}
