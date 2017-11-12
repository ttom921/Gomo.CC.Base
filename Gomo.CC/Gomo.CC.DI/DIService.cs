






using Autofac;
using Gomo.CC.BLL;
using Gomo.CC.IBLL;
namespace Gomo.CC.DIModule
{

	public class ServiceModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<BlogService>()
				.As<IBlogService>().InstancePerLifetimeScope();

			builder.RegisterType<PostService>()
				.As<IPostService>().InstancePerLifetimeScope();

		}
	}
}


