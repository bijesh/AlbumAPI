using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumAPI.Interface;
using AlbumAPI.Service;
using AlbumAPI.Utilities;
using AlbumAPI.ViewModelBuilder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AlbumAPI
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
            services.AddTransient<IWebApiClient, WebApiClient>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IAlbumViewModelBuilder, AlbumViewModelBuilder>();
            services.AddTransient<IPhotoViewModelBuilder, PhotoViewModelBuilder>();
            services.AddTransient<IUserAlbumViewModelBuilder, UserAlbumViewModelBuilder>();

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
                //endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Album}/{action=Get}/{userId?}");
            });
        }
    }
}
