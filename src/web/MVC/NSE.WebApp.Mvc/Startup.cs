using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.Mvc.Configuration;
using NSE.WebApp.MVC.Configuration;

namespace NSE.WebApp.Mvc
{
    public class Startup
    {
        public Startup(IHostingEnvironment hostEnviroment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnviroment.ContentRootPath)
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnviroment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnviroment.IsDevelopment()){
                builder.AddUserSecrets<Startup>();
            }
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration();

            services.AddAppConfiguration(Configuration);

            services.RegisterService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAppConfiguration(env);
        }
    }
}
