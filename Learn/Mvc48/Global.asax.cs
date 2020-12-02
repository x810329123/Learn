using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml;

namespace Mvc48
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {



            //var configFile = ConfigurationManager.OpenExeConfiguration(fileName);
            //configFile.AppSettings.Settings[key].Value = value;

            //configFile.Save();

            //ReadAllSettings();
            //ReadSetting("Setting1");
            //ReadSetting("NotValid");
            //AddUpdateAppSettings("NewSetting", "May 7, 2014");
            //AddUpdateAppSettings("Setting1", "May 8, 2014");
            //ReadAllSettings();

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

        static void ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
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
