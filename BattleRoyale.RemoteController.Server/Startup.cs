using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BatteRoyale.RemoteController.Server;
using BatteRoyale.RemoteController.Server.Services;
using BattleRoyale.RemoteController.Server.CrossCutting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BattleRoyale.RemoteController.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddWebSocketManager();
            services.AddMvc();
            IoC.ApplyServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            // adding support to WebSockets
            //app.UseWebSockets();
            //app.MapWebSocketManager("/ws", serviceProvider.GetService<CommandLineWebSocketHandler>());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors(b => b.WithOrigins("http://localhost:8081/"));
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

        }


    }

    //public static class StartupExtensions {
    //    // reference: https://radu-matei.com/blog/aspnet-core-websockets-middleware/
    //    public static IApplicationBuilder MapWebSocketManager(this IApplicationBuilder app,
    //                                                          PathString path,
    //                                                          WebSocketHandler handler)
    //    {
    //        return app.Map(path, (_app) => _app.UseMiddleware<WebSocketManagerMiddleware>(handler));
    //    }

    //    public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
    //    {
    //        services.AddTransient<WebSocketConnectionManager>();

    //        foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
    //        {
    //            if (type.GetTypeInfo().BaseType == typeof(WebSocketHandler))
    //            {
    //                services.AddSingleton(type);
    //            }
    //        }

    //        return services;
    //    }
    //}

}
