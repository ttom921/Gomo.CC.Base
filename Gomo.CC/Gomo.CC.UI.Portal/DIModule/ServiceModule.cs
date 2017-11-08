using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Gomo.CC.IBLL;
using System.Reflection;

namespace Gomo.CC.UI.Portal.DIModule
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(typeof(IBlogService).GetTypeInfo().Assembly).AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
