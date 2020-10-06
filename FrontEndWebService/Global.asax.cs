using System;
using Autofac;
using Autofac.Integration.Web;
using FE.Context;

namespace FrontEndWebService
{
    public class Global : System.Web.HttpApplication
        //,IContainerProviderAccessor
    {
        public static IContainerProvider ContainerProvider;
        //IContainerProvider IContainerProviderAccessor.ContainerProvider => ContainerProvider;

        protected void Application_Start(object sender, EventArgs e)
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterType<FrontEndContext>().AsSelf();
            //var container = builder.Build();
            //ContainerProvider = new ContainerProvider(container);
        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}