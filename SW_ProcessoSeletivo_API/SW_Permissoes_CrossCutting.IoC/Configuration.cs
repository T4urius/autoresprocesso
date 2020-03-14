using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SW_Permissoes_Domain.DTOs.AWSCognito;
using SW_Permissoes_Domain.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW_Permissoes_CrossCutting.IoC
{
    public static class Configuration
    {
        public static void AddRegisterIoCServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterMediator(services);
            RegisterData(services);
            RegistrarCognitoConfig(services);
            RegistrarCognitoAppServices(services);
            RegistrarHttpServices(services);
            RegistrarServices(services);
        }

        public static void RegistrarServices(IServiceCollection services)
        {
            //services.AddScoped<ISendEmailService, SendEmailSMTPService>();
        }

        private static void RegistrarHttpServices(IServiceCollection services)
        {
            services.AddHttpClient();
            //services.AddScoped<Domain.Contracts.Services.IEntidadeService, Services.Http.Entidade.EntidadeService>();
            //services.AddTransient<Domain.Contracts.Services.IAplicacaoInstanciaService, Services.Http.AplicacaoInstancia.AplicacaoInstanciaService>();
        }

        private static void RegisterMediator(IServiceCollection services)
        {
            var domain = "SW_Permissoes_Domain";

            var assembly = AppDomain.CurrentDomain.Load(domain);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
            services.AddMediatR(AppDomain.CurrentDomain.Load(domain));
        }

        private static void RegisterData(IServiceCollection services)
        {
            //services.AddScoped<SwAuthDataContext>();

            //services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services.AddTransient<IAplicacaoInstanciaService, AplicacaoInstanciaService>();
        }
        private static void RegistrarCognitoAppServices(IServiceCollection services)
        {
            //services.AddTransient<ICognitoAuthService, CognitoAuthService>();
            //services.AddTransient<ICognitoUserService, CognitoUserService>();
            //services.AddTransient<IEntidadesAPIService, EntidadesAPIService>();
        }
        private static void RegistrarCognitoConfig(IServiceCollection services)
        {
            services.AddCognitoIdentity(config =>
            {
                config.Password = new Microsoft.AspNetCore.Identity.PasswordOptions
                {
                    RequireDigit = false,
                    RequiredLength = 6,
                    RequiredUniqueChars = 0,
                    RequireLowercase = false,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false
                };
            });

            var sp = services.BuildServiceProvider();
            var cognitoUserPoolConfigurations = (CognitoUserPoolConfigurationsDTO)sp
                    .GetService(typeof(CognitoUserPoolConfigurationsDTO));


            var credentials = new BasicAWSCredentials(cognitoUserPoolConfigurations.AccessKey, cognitoUserPoolConfigurations.SecretKey);
            var provider =
                new AmazonCognitoIdentityProviderClient(credentials, RegionEndpoint.GetBySystemName(cognitoUserPoolConfigurations.Region));
            services.AddSingleton<IAmazonCognitoIdentityProvider>(provider);

            var cognitoUserPool =
                    new CognitoUserPool(
                        cognitoUserPoolConfigurations.PoolId,
                        cognitoUserPoolConfigurations.ClientId,
                        provider, cognitoUserPoolConfigurations.ClientSecretKey);

            services.AddSingleton(cognitoUserPool);
        }
    }
}
