using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Dominio.Retorno;
using Infrastructure;
using Infrastructure.Configuracoes;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using Service.Services.Implementacoes;

namespace Api
{
    public static class Configuracao
    {

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
            ServicesConfiguration.AddScoped<ICompromissoServico, CompromissoServico>();

        }

        private static void ConfigurarRepositorios(IServiceCollection ServicesConfiguration)
        {
            ServicesConfiguration.AddSingleton<ICompromissoRepositorio, CompromissoRepositorio>();
        }


        public static void Configurar(IServiceCollection ServicesConfiguration, IConfiguration Configuration)
        {
            ConfigurarServicos(ServicesConfiguration);
            ConfigurarRepositorios(ServicesConfiguration);
            ConfigurarSwagger(ServicesConfiguration);

            var mapperConfig = AdapterDtoDomain.MapperRegister();
            var mapper = mapperConfig.CreateMapper();

            ConfiguracaoBancoDeDados configuracaoRepositorio = new()
            {
                SQLConnectionString = Environment.GetEnvironmentVariable("SQL_CONNECTIONSTRING") ?? string.Empty,
            };

            ServicesConfiguration
                .AddSingleton(configuracaoRepositorio)
                .AddSingleton<ConexaoSQL>()
                .AddScoped<MensagemRetorno>()
                .AddSingleton(mapper);
        }
    }
}
