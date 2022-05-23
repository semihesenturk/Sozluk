using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Infrastructure.Persistence.Context;
using Sozluk.Infrastructure.Persistence.Repositories;

namespace Sozluk.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastractureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SozlukContext>(
            conf =>
            {
                var connStr = configuration["SozlukDbConnectionString"].ToString();
                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

        //Seed startup datas
        var seedData = new SeedData();
        seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEntryRepository, EntryRepository>();
        services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();
        services.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();

        return services;
    }
}

