using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ElearningProjectAdminAPI.Extentions
{
    public static class ApplicationBuilderExtention
    {
        public static void GlobalExceptionHandler(this IApplicationBuilder app)
        {
            //Removes the need for try-catch code anywhere.
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error =
                   context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        await context.Response.WriteAsync($" Status code : {context.Response.StatusCode} Error_Message : {ex.Message}"); //To be changed later on
                    }
                });
            });
        }
    }
}
