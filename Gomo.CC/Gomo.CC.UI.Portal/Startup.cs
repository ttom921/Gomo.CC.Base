using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Gomo.CC.Model;
using Gomo.CC.IDAL;
using Gomo.CC.EFDal;
using Gomo.CC.EFDAL;
using Gomo.CC.IBLL;
using Gomo.CC.BLL;
using Autofac;
using Gomo.CC.UI.Portal.DIModule;
using Autofac.Extensions.DependencyInjection;
using log4net.Repository;
using log4net;
using log4net.Config;
using System.IO;

namespace Gomo.CC.UI.Portal
{
    public class Startup
    {
        static ILoggerRepository logorep { get; set; }
        public ILog log;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //SetUpLog
            SetUpLog();
        }
        //設定log
        private void SetUpLog()
        {
            logorep = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(logorep, new FileInfo("log4net.config"));
            log = LogManager.GetLogger(logorep.Name, typeof(Startup));
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            log.Info("start ConfigureServices...");
            // Add framework services.
            services.AddMvc();
            //連結資料庫
            services.AddDbContext<BloggingContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));
            // services.AddDbContext<BloggingContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("myHome")));







            //// create custom container
            //var container = new CustomContainer();
            //// read service collection to the custom container
            //container.RegisterFromServiceCollection(services);
            //// use and configure the custom container
            //container.RegisterSingelton<IProvider, MyProvider>();
            //// creating the IServiceProvider out of the custom container
            //return container.BuildServiceProvider();

            //autofac container
            var builder = new ContainerBuilder();
            // read service collection to Autofac
            builder.Populate(services);
            // use and configure Autofac
            builder.RegisterModule<DalModule>();
            builder.RegisterModule<ServiceModule>();
            // build the Autofac container
            ApplicationContainer = builder.Build();
            // creating the IServiceProvider out of the Autofac container
            //return new AutofacServiceProvider(ApplicationContainer);
            log.Info("Done ConfigureServices...");
            return ApplicationContainer.Resolve<IServiceProvider>();
            //
            //var builder = new ContainerBuilder();
            //builder.RegisterModule<DalModule>();
            //builder.RegisterModule<ServiceModule>();
            //builder.Populate(services);
            //ApplicationContainer = builder.Build();
            //return ApplicationContainer.Resolve<IServiceProvider>();
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
