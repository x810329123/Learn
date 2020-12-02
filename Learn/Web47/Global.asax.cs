using Microsoft.Extensions.Hosting;
using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml;

namespace Web47
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ReadAllSettings();
            string[] emails = ConfigurationManager.AppSettings["email"].Split(';');
            string userName = ConfigurationManager.AppSettings["webpages:Version"];
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }
    }



    public class SampleConfigurationBuilder : ConfigurationBuilder
    {

        public override XmlNode ProcessRawXml(XmlNode rawXml)
        {

            string rawXmlString = rawXml.OuterXml;

            if (String.IsNullOrEmpty(rawXmlString))
            {
                return rawXml;
            }

            rawXmlString = Environment.ExpandEnvironmentVariables(rawXmlString);

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(rawXmlString);
            return doc.DocumentElement;
        }

        public override ConfigurationSection ProcessConfigurationSection(ConfigurationSection configSection)
            => configSection;
    }
}
