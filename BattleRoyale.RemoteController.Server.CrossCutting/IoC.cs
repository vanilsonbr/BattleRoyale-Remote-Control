using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using BatteRoyale.RemoteController.Server.Services;
using BatteRoyale.RemoteController.Server.Services.Interface;

namespace BattleRoyale.RemoteController.Server.CrossCutting
{
    public class IoC
    {
        public static void ApplyServices(IServiceCollection services)
        {

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            //var mapperConfig = new MapperConfiguration(config => config.AddProfile<RemoteControllerProfile>());
            //mapperConfig.AssertConfigurationIsValid();

            //Services
            services.AddSingleton<IRemoteControlService, RemoteControlService>();
        }
    }
}
