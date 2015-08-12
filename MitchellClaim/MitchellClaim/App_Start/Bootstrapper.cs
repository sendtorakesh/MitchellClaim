using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Web.Http;

namespace MitchellClaim.App_Start
{
    /// <summary>
    /// Responsible for bootstrapping IoC container.
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(BuildUnityContainer());
            var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            xml.UseXmlSerializer = true;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            UnityContainer tempContainer = null;
            UnityContainer container;

            try
            {
                tempContainer = new UnityContainer();

                // Register your container mappings in the config file.
                // It will get loaded into the container with the following call:
                tempContainer.LoadConfiguration();

                container = tempContainer;
                tempContainer = null;
            }
            finally
            {
                if (tempContainer != null)
                {
                    tempContainer.Dispose();
                }
            }

            return container;
        }
    }
}




