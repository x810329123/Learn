using DataModels;
using Linq2dbTool;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnLinq2dbDemo
{
    class Program
    {
        private static DbTstMall DbTstMall { get; set; }
        static void Main(string[] args)
        {
            InitialDataConnection();
            Read();
            ReadSelectingColumns();
            ReadComposingQueries();
            ReadWithJoin();
            //Insert();
            //InsertWithInt32Identity();
            //InsertSpecificColumn();
            //Update();
            //UpdateCombine();
            //UpdateMutiple();
            //Delete();
            BulkCopy();

            Console.ReadLine();
        }

        private static void InitialDataConnection()
        {
            SetDefaultDataConnection();
            DbTstMall = new DbTstMall();
        }

        private static void SetDefaultDataConnection()
        {
            DataConnection.DefaultSettings = new TstMallDbSettings();
        }

        private static void Read()
        {
            var result = DbTstMall.Customer.Take(10).ToList();
            result.ForEach(customer => Console.WriteLine(customer.Email));
        }

        private static void ReadSelectingColumns()
        {
            var result = DbTstMall.Customer.Take(10).Select(customer => new { Id = customer.Id }).ToList();
            result.ForEach(customer => Console.WriteLine(customer.Id));
        }

        private static void ReadComposingQueries()
        {
            var result = DbTstMall.Customer.Where(x => x.Email.StartsWith("j"));
            result = result.Take(10);
            result.ToList().ForEach(customer => Console.WriteLine(customer.Email));
        }

        private static void ReadWithJoin()
        {
            var result = DbTstMall.Customer
                .Join(
                DbTstMall.CustomerPassword,
                customer => customer.Id,
                customerPassword => customerPassword.CustomerId,
                (customer, customerPassword) => new
                {
                    customer.Id,
                    CustomerPassword = customerPassword
                });

            result = result.Take(10);
            result.ToList().ForEach(customer => Console.WriteLine($"{customer.Id}密碼{customer.CustomerPassword.Password}"));
        }

        private static void Insert()
        {
            Test test = new Test() { Id = 1, Text = DateTime.UtcNow.ToString() };
            DbTstMall.Insert(test);
        }

        private static void InsertWithInt32Identity()
        {
            TestIdentity testIdentity = new TestIdentity() { Text = "1" };
            DbTstMall.InsertWithInt32Identity(testIdentity);
        }

        private static void InsertSpecificColumn()
        {
            DbTstMall.Test
                .Value(p => p.Text, DateTime.UtcNow.ToString())
                .Insert();
        }

        private static void Update()
        {
            var result = DbTstMall.TestIdentity.Where(testIdentity => testIdentity.Id == 1).Single();
            result.Text = DateTime.UtcNow.ToString();
            DbTstMall.Update(result);

            DbTstMall.TestIdentity
                .Where(testIdentity => testIdentity.Id == 2)
                .Set(testIdentity => testIdentity.Text, DateTime.UtcNow.ToString())
                .Update();
        }

        private static void UpdateCombine()
        {

            var statement = DbTstMall.TestIdentity
                .Where(testIdentity => testIdentity.Id == 3)
                .Set(testIdentity => testIdentity.Text, DateTime.UtcNow.ToString());
            statement = statement.Set(testIdentity => testIdentity.Remark, DateTime.UtcNow.ToString());
            statement.Update();
        }

        private static void UpdateMutiple()
        {

            var statement = DbTstMall.TestIdentity
                .Where(testIdentity => testIdentity.Id < 3)
                .Set(testIdentity => testIdentity.Text, DateTime.UtcNow.ToString());
            statement.Update();
        }

        private static void Delete()
        {
            DbTstMall.Test
                .Where(test => test.Id == 1)
                .Delete();
        }

        private static void BulkCopy()
        {
            DbTstMall.Test.Truncate();
            List<Test> tests = new List<Test>();
            foreach (int i in Enumerable.Range(0, 10000))
            {
                tests.Add(new Test() { Id = i, Text = DateTime.UtcNow.ToString() });
            }
            DbTstMall.BeginTransaction();

            DbTstMall.BulkCopy(tests);

            bool isError = false;

            if (isError)
            {
                DbTstMall.RollbackTransaction();
            }
            else
            {
                DbTstMall.CommitTransaction();
            }
        }
    }
}
