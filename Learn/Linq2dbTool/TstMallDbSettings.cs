﻿using LinqToDB.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq2dbTool
{
    public class TstMallDbSettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();
        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "tstMallDB",
                        ProviderName = "SqlServer",
                        //ConnectionString = @"Data Source=(localdb)\DEVELOPMENT;Initial Catalog=tstMallDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"
                        ConnectionString = @"Server=tcp:cblaxokqm4.database.windows.net,1433;Database=StayfunDbTst;User ID=_sa@cblaxokqm4;Password=Hn54510058;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;ConnectRetryCount=6;ConnectRetryInterval=5;"
                    };
            }
        }
    }
}
