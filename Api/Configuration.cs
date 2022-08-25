using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Services;
using Domain.Interfaces.Servicos;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Service.Services;
using System.Text;

namespace Api
{
    public static class Configuration
    {
        private static void ConfigureTokenJwt(IServiceCollection ServicesConfiguration, IConfiguration configuration)
        {
            ServicesConfiguration.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            var key = configuration.GetValue<string>("TokenKey");

            Console.WriteLine(key);
            var keyBytes = Encoding.ASCII.GetBytes(key);

            ServicesConfiguration.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        private static void ConfigureSwagger(IServiceCollection ServicesConfiguration)
        {
            ServicesConfiguration.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.",
                });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         Array.Empty<string>()
                    }
                });
            });

        }

        private static void ConfigureServices(IServiceCollection ServicesConfiguration)
        {
            ServicesConfiguration.AddScoped<ILoginService, LoginService>();
            ServicesConfiguration.AddScoped<IUserService, UserService>();
            ServicesConfiguration.AddScoped<ITokenService, TokenService>();

        }

        private static void ConfigureRepositories(IServiceCollection ServicesConfiguration)
        {
            ServicesConfiguration.AddSingleton<IUserRepository, UserRepository>();
            ServicesConfiguration.AddSingleton<ILoginRepository, LoginRepository>();
        }


        public static void Configure(IServiceCollection ServicesConfiguration, IConfiguration Configuration)
        {
            ConfigureServices(ServicesConfiguration);
            ConfigureRepositories(ServicesConfiguration);
            ConfigureSwagger(ServicesConfiguration);
            ConfigureTokenJwt(ServicesConfiguration, Configuration);
        }
    }
}
