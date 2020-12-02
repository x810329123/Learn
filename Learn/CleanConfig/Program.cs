using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Web;

namespace CleanConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> configuration = new List<string>() { "Debug", "UAT", "PrePRD", "PROD" };
            //Dictionary<string, Dictionary<string, (string Comment, string Value)>> rawConfigs = new Dictionary<string, Dictionary<string, (string Comment, string Value)>>();
            //Dictionary<string, (string Comment, string Value)> currentConfiguration = null;
            //string currentComment = null;

            //foreach (var c in configuration)
            //{
            //    XmlDocument doc = new XmlDocument();
            //    doc.Load($@"C:\Users\jake_li\source\repos\stayfun\WCPT\AppSettings.{c}.config");
            //    XmlNodeList nodeList = doc.SelectNodes("/appSettings");
            //    currentConfiguration = new Dictionary<string, (string Comment, string Value)>();
            //    rawConfigs.Add(c, currentConfiguration);
            //    foreach (XmlNode no in nodeList)
            //    {
            //        XmlNodeList nodeListChild = no.ChildNodes;
            //        foreach (XmlNode noChild in nodeListChild)
            //        {
            //            if (noChild.NodeType == XmlNodeType.Comment)
            //            {
            //                currentComment = noChild.Value.Trim();
            //                continue;
            //            }

            //            var key = noChild.Attributes["key"].Value;
            //            var value = noChild.Attributes["value"].Value;
            //            value = HttpUtility.HtmlEncode(value);
            //            currentConfiguration.Add(key, (currentComment, value));
            //        }
            //    }
            //}



            //List<(string concatValue, string key, string comment, string value)>
            //    counter = new List<(string concatValue, string key, string comment, string value)>();

            //foreach (var configurationConfig in rawConfigs)
            //{
            //    foreach (var config in configurationConfig.Value)
            //    {
            //        string concat = $"{config.Key}_^_{config.Value.Value}";
            //        counter.Add((concat, config.Key, config.Value.Comment, config.Value.Value));
            //    }
            //}

            ////GetBase
            //Dictionary<string, (string Comment, string Value)> baseConfig = null;
            //baseConfig = counter.GroupBy(x => x.concatValue).Where(x => x.Count() == 4)
            //    .ToDictionary(x => x.First().key, x => (x.First().comment, x.First().value));

            //Dictionary<string, Dictionary<string, (string Comment, string Value)>> result = new Dictionary<string, Dictionary<string, (string Comment, string Value)>>();

            //foreach (var configsByConfiguration in rawConfigs)
            //{
            //    result.Add(configsByConfiguration.Key, new Dictionary<string, (string Comment, string Value)>());
            //    foreach (var configs in configsByConfiguration.Value)
            //    {
            //        if (!baseConfig.TryGetValue(configs.Key, out (string Comment, string Value) baseInfo))
            //        {
            //            result[configsByConfiguration.Key].Add(configs.Key, (configs.Value.Comment, configs.Value.Value));
            //        }
            //    }
            //}

            //result.Add("Base", baseConfig);


            //foreach (var configsByConfiguration in result)
            //{
            //    StringBuilder stringBuilder = new StringBuilder();
            //    string commentCurrent = null;
            //    var isBase = configsByConfiguration.Key.Equals("Base");
            //    var transformAppSettings = isBase ? string.Empty : @" xdt:Transform=""Replace""";
            //    var insertIsMissing = isBase ? @" xdt:Transform=""InsertIfMissing"" xdt:Locator=""Match(key)""" : string.Empty;
            //    stringBuilder.AppendLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            //    stringBuilder.AppendLine($@"<appSettings xmlns:xdt=""http://schemas.microsoft.com/XML-Document-Transform""{transformAppSettings}>");

            //    foreach (var configs in configsByConfiguration.Value)
            //    {
            //        if (commentCurrent == null || !commentCurrent.Equals(configs.Value.Comment))
            //        {
            //            commentCurrent = configs.Value.Comment;
            //            stringBuilder.AppendLine($@"    <!--{commentCurrent}-->");
            //        }
            //        stringBuilder.AppendLine($@"    <add key=""{ configs.Key}"" value=""{configs.Value.Value}""{insertIsMissing}/>");
            //    }
            //    stringBuilder.AppendLine(@"</appSettings>");
            //    Console.WriteLine(configsByConfiguration.Key);
            //    Console.WriteLine(stringBuilder.ToString());
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            //Console.ReadLine();
        }
    }
}
