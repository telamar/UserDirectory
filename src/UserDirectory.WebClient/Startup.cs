using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.DependencyInjection;

namespace UserDirectory.WebClient
{
    public class Startup
    {
        private const string SpaFilePath = "ClientApp";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddNodeServices(options =>
            {
                options.ProjectPath = Path.Combine(Directory.GetCurrentDirectory(), SpaFilePath);
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = SpaFilePath;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseWebpackDevMiddleware(
                    new WebpackDevMiddlewareOptions
                    {
                        HotModuleReplacement = true
                    });
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSpa(spaBuilder =>
            {
                spaBuilder.Options.SourcePath = SpaFilePath;
            });
        }
    }
}