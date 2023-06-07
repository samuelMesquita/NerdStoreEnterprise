using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
{
    public class ExceptionMiddliware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddliware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(CustomHttpRequestException ex)
            {
                //caso a exception seja do tipo CustomHttpRequestException o erro sera tratado no HandlerExceptionRequestAsync.
                HandlerExceptionRequestAsync(httpContext, ex);
            }
        }

        private static void HandlerExceptionRequestAsync(HttpContext httpContext, CustomHttpRequestException ex)
        {
            if(ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                httpContext.Response.Redirect($"/login?returnUrl={httpContext.Request.Path}");
                return;
            }

            httpContext.Response.StatusCode = (int)ex.StatusCode;
        }
    }
}
