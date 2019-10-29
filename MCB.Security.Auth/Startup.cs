using MCB.Security.Auth.Handlers.Login;
using MCB.Security.Auth.Handlers.Refresh;
using MCB.Security.Infrastructure.Data.Repositories;
using MCB.Security.Infrastructure.TokenProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MCB.Security.Auth
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
            services.AddControllers();
            services.AddApiVersioning();

            ConfigureInjection(services);
            services.AddSecurityProvider(options =>
            {
                options.UseJwt();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MCB Security API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MCB Security API V1");
                c.RoutePrefix = string.Empty;
            });
        }

        private void ConfigureInjection(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITokenProviderFactory, TokenProviderFactory>();
            services.AddSingleton<ILoginRequestHandler, LoginRequestHandler>();
            services.AddSingleton<IRefreshTokenRequestHandler, RefreshTokenRequestHandler>();
        }
    }
}
