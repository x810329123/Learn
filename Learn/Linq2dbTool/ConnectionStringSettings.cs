using LinqToDB.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linq2dbTool
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }
}
