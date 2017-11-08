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
using Autofac;
using Gomo.CC.UI.Portal.DIModule;
using Autofac.Extensions.DependencyInjection;

namespace Gomo.CC.UI.Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc();
            //連結資料庫
            services.AddDbContext<BloggingContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));

            // services.AddDbContext<BloggingContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("myHome")));


            //var builder = new ContainerBuilder();
            //builder.RegisterType<BlogDal>()
            //   .As<IBlogDal>().InstancePerDependency();

            //builder.RegisterType<BlogService>()
            //    .As<IBlogService>().InstancePerDependency();
            //builder.Populate(services);

            //var container = builder.Build();

            //return container.Resolve<IServiceProvider>();

            //
            var builder = new ContainerBuilder();
            builder.RegisterModule<DalModule>();
            builder.RegisterModule<ServiceModule>();
            builder.Populate(services);
            ApplicationContainer = builder.Build();
            return ApplicationContainer.Resolve<IServiceProvider>();
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
