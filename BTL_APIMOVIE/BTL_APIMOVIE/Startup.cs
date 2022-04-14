using Microsoft.AspNetCore.Builder;

namespace BTL_APIMOVIE
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            // Shows UseCors with CorsPolicyBuilder.
            
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44370")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
        }

    }
}
