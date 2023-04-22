using AutoMapper;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Services;
using Domain.Interfaces.Servicos;
using Domain.Retorno;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Service.Services.Implementacoes;
using System.Text;

namespace Api
{
    public static class Configuracao
    {
        private static void ConfigurarTokenJwt(IServiceCollection ServicesConfiguration, IConfiguration configuration)
        {
            ServicesConfiguration.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            var key = configuration.GetValue<string>("TokenKey");

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

        private static void ConfigurarSwagger(IServiceCollection ServicesConfiguration)
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

        private static void ConfigurarServicos(IServiceCollection ServicesConfiguration)
        {
            ServicesConfiguration.AddScoped<IAuthService, AuthService>();
            ServicesConfiguration.AddScoped<ICompromissoServico, CompromissoServico>();
            ServicesConfiguration.AddScoped<ITokenService, TokenService>();

        }

        private static void ConfigurarRepositorios(IServiceCollection ServicesConfiguration)
        {
            ServicesConfiguration.AddSingleton<ICompromissoRepositorio, CompromissoRepositorio>();
            ServicesConfiguration.AddSingleton<IAuthRepositorio, AuthRepositorio>();
        }


        public static void Configurar(IServiceCollection ServicesConfiguration, IConfiguration Configuration)
        {
            ConfigurarServicos(ServicesConfiguration);
            ConfigurarRepositorios(ServicesConfiguration);
            ConfigurarSwagger(ServicesConfiguration);
            ConfigurarTokenJwt(ServicesConfiguration, Configuration);

            var mapperConfig = AdapterDtoDomain.MapperRegister();
            var mapper = mapperConfig.CreateMapper();

            ServicesConfiguration
                .AddSingleton<ConexaoSQL>()
                .AddScoped<MensagemRetorno>()
                .AddSingleton(mapper);
        }
    }
}
