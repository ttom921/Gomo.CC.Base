






using Autofac;
using Gomo.CC.EFDAL;
using Gomo.CC.IDAL;
using Gomo.CC.Model;
namespace Gomo.CC.DIModule
{

	public class DalModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<BlogDal>()
				.As<IBlogDal>().InstancePerLifetimeScope();

			builder.RegisterType<PostDal>()
				.As<IPostDal>().InstancePerLifetimeScope();

		}
	}
}


