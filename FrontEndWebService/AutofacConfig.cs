using Autofac;
using FE.Context;

namespace FrontEndWebService
{
    public class AutofacConfig
    {
        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FrontEndContext>().AsSelf();
            var container = builder.Build();
            
           // var resolver = new AutofacDependencyResolver(container);
            //DependencyResolver.SetResolver(resolver);
        }
    }
}