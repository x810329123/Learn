using DataModels;
using LinqToDB;
using LinqToDB.Data;
using System.Collections.Generic;
using System.Linq;

namespace Linq2dbTool
{
    public class DbTstMall : DataConnection
    {
        public ITable<Customer> Customer => GetTable<Customer>();
        public ITable<CustomerPassword> CustomerPassword => GetTable<CustomerPassword>();
        public ITable<Test> Test => GetTable<Test>();
        public ITable<TestIdentity> TestIdentity => GetTable<TestIdentity>();
        public ITable<JoinClubOrder> JoinClubOrderIdentity => GetTable<JoinClubOrder>();
    }
}
