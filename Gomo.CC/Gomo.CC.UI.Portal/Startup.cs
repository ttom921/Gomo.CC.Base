using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Gomo.CC.Model.Models;
using Gomo.CC.IDAL;
using Gomo.CC.EFDal;
using Gomo.CC.EFDAL;
using Gomo.CC.IBLL;
using Gomo.CC.BLL;

namespace Gomo.CC.UI.Portal
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



            
            services.AddMvc();
            //var connection = @"Data Source=DESKTOP-NITSS8T;Initial Catalog=Blogging;User ID=sa;Password=12345678;";
            //services.AddDbContext<BloggingContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<BloggingContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));

           // services.AddDbContext<BloggingContext>(options =>
           //options.UseSqlServer(Configuration.GetConnectionString("myHome")));


            // Register application services.
            services.AddTransient<IBlogDal, BlogDal>();
            services.AddTransient<IBlogService, BlogService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
