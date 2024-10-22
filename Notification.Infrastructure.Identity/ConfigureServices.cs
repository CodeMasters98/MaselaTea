using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Notification.Domain.Settings;
using System.Text;

namespace Notification.Infrastructure.Identity;

public static class ConfigureServices
{
    public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services, string connectionString, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>(options => options.UseInMemoryDatabase("PD_Identity"));

        //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        //{

        //}
        //else
        //{
        //    services.AddDbContextIdentityContext>(options =>
        //        options.UseSqlServer(
        //        configuration.GetConnectionString("PD_Identity"),
        //            b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));
        //}

        //services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

        services
            .AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

        #region Services
        //services.AddTransient<IAccountService, AccountService>();
        #endregion

        services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSetting:ValidIssuer"],
                    ValidAudience = configuration["JwtSetting:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Secret"]))
                };
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        //new Response<string>("You are not Authorized")
                        var result = JsonConvert.SerializeObject("");
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        //new Response<string>("You are not authorized to access this resource")
                        var result = JsonConvert.SerializeObject("/");
                        return context.Response.WriteAsync(result);
                    },
                };
            });


        return services;
    }
}