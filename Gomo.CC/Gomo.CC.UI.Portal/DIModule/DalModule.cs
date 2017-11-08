using Autofac;
using Gomo.CC.EFDAL;
using Gomo.CC.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Gomo.CC.UI.Portal.DIModule
{
    public class DalModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogDal>()
               .As<IBlogDal>().InstancePerLifetimeScope();
        }
    }
}
