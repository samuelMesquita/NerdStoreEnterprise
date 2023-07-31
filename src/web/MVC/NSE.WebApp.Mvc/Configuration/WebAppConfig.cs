using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.WebApp.MVC.Extensions;
using Nse.WebApi.Core;
using Microsoft.Extensions.Configuration;

namespace NSE.WebApp.Mvc.Configuration
{
    public static class WebAppConfig
    {
        public static void AddAppConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            services.Configure<Nse.WebApi.Core.AppSettings>(configuration);
        }

        public static void UseAppConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //caso seja um erro não registrado no meu middleware, sera tratado como erro de servidor na rota 500
                app.UseExceptionHandler("/erro/500");
                //caso seja um erro com um status code registrado, o usuario sera redirecionado para rota de erro com o status code que foi registrado.
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseJwtConfig();

            //Registrando o middleware no pipeline da aplicação
            app.UseMiddleware<ExceptionMiddliware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
