﻿using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddHttpClient<IAuthenticationService, AuthenticationService>();
        }
    }
}
