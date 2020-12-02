using DataModels;
using Linq2dbTool;
using LinqToDB;
using LinqToDB.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace LearnLinq2dbDemo
{
    public abstract class BaseApiResult<T>
    {
        public string Code;
        public string Message;
        public T Data;
    }

    public class DataResult<T> : Result
    {
        public T Data { get; set; }
    }

    public class Result
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    internal class Schema
    {
        internal int Id { get; set; }
        internal string Value { get; set; }
    }

    public class TubeEmployeeDataListParam
    {
        public List<TubeEmployeeDataParam> data { get; set; }
    }

    public class TubeEmployeeDataParam
    {
        public string companyid { get; set; }

        [Required(ErrorMessage = "Parameter userId is missing")]
        public string userId { get; set; }

        [Required(ErrorMessage = "Parameter employedStatus is missing")]
        public int employedStatus { get; set; }

        [Required(ErrorMessage = "Parameter userName is missing")]
        public string userName { get; set; }

        public string birthday { get; set; }

        /// <summary>
        /// 帳號屬性
        /// </summary>
        [Required(ErrorMessage = "Parameter AccountAttribute is missing")]
        public AccountAttributeEnum AccountAttribute { get; set; }
    }

    public enum AccountAttributeEnum
    {
        /// <summary>
        /// 一般
        /// </summary>
        General = 0,

        /// <summary>
        /// HRM
        /// </summary>
        /// <remarks>
        /// XE
        /// </remarks>
        HRM = 1,

        /// <summary>
        /// Apollo
        /// </summary>
        Apollo = 2,

        /// <summary>
        /// Facebook
        /// </summary>
        Facebook = 3,

        /// <summary>
        /// google
        /// </summary>
        Google = 4
    }



    class Program
    {

        private DataResult<Schema> Get()
        {
            return null;
        }

        private static DbTstMall DbTstMall { get; set; }
        static void Main(string[] args)
        {
            foreach (int i in Enumerable.Range(0, 10000))
            {
                using (WebClient webClient = new WebClient())
                {
                    // 指定 WebClient 編碼
                    webClient.Encoding = Encoding.UTF8;
                    // 指定 WebClient 的 Content-Type header
                    webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    // 指定 WebClient 的 authorization header
                    webClient.Headers.Add("AuthorizedKey", "b85fcb38-016e-4e5a-a40f-8dd575850aeb");
                    webClient.Headers.Add("AccessToken", "UNNEpT8dahjZcJgmXHzw0fQyv1LtN7gelCqeVkSAszOlt6ZMt8apo442gH6s4xuiltfSmuq12PX5aKb1qhRAodAs0H82LH7gO43HUoD6utI=");
                    // 準備寫入的 data

                    TubeEmployeeDataListParam tubeEmployeeDataListParam = new TubeEmployeeDataListParam();
                    tubeEmployeeDataListParam.data = new List<TubeEmployeeDataParam>();
                    tubeEmployeeDataListParam.data.Add(new TubeEmployeeDataParam()
                    {
                        AccountAttribute = AccountAttributeEnum.Apollo,
                        birthday = "",
                        companyid = "",
                        employedStatus = 1,
                        userId = "",
                        userName = ""
                    });
                    tubeEmployeeDataListParam.data.Add(new TubeEmployeeDataParam()
                    {
                        AccountAttribute = AccountAttributeEnum.Apollo,
                        birthday = "",
                        companyid = "",
                        employedStatus = 1,
                        userId = "",
                        userName = ""
                    });
                    tubeEmployeeDataListParam.data.Add(new TubeEmployeeDataParam()
                    {
                        AccountAttribute = AccountAttributeEnum.Apollo,
                        birthday = "",
                        companyid = "",
                        employedStatus = 1,
                        userId = "",
                        userName = ""
                    });
                    tubeEmployeeDataListParam.data.Add(new TubeEmployeeDataParam()
                    {
                        AccountAttribute = AccountAttributeEnum.Apollo,
                        birthday = "",
                        companyid = "",
                        employedStatus = 1,
                        userId = "",
                        userName = ""
                    });

                    // 將 data 轉為 json
                    string json = JsonConvert.SerializeObject(tubeEmployeeDataListParam);

                    string jsonf = @"{""Data"":
[{
    ""UserID"":""cicicandy161@yahoo.com.tw"",
    ""EmployedStatus"":2,
    ""UserName"":""曾予欣"",
    ""Birthday"":""1986-10-23T00:00:00+08:00"",
    ""AccountAttribute"":1}
]
    
}

正常：
{""Data"":
[{
    ""UserID"":""swatorey@hotmail.com"",
    ""EmployedStatus"":2,
    ""UserName"":""王湘鈞"",
    ""Birthday"":""1993-06-01T00:00:00+08:00"",
    ""AccountAttribute"":1}
]
    
}
";

                    // 執行 post 動作
                    var result = webClient.UploadString("https://tst-stayfun.mayohr.com/api/ClientIn/UpdateTubeEmployeeDataToStayfun", jsonf);
                    // linqpad 將 post 結果輸出
                    //result.Dump();
                    if (result.Contains("502"))
                    {

                    }
                }
            }
















            //var timestampFormat = "MMddHHmmss";
            //    var randomValue = new Random(Guid.NewGuid().GetHashCode()).Next(60, 99);
            //    timestampFormat = "MMddHHmm" + randomValue;
            //randomValue = 98;

            //DateTime dateTime = new DateTime(2020, 01, 01, 23, 59, 59);

            //var value = int.Parse(dateTime.ToString(timestampFormat));

            //var encrypCodeBase34 = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";

            //var length = encrypCodeBase34.Length;
            //var converedValue = string.Empty;
            //while (value >= 1)
            //{
            //    var index = Convert.ToInt32(value % length);
            //    converedValue = encrypCodeBase34[index] + converedValue;
            //    value = value / length;
            //}

            













            //DataResult<Schema> apiResult = new DataResult<Schema>();
            //apiResult.Data = new Schema();







            //var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\w{8,12}$";
            //string input = "88g8G88666666";
            //var regex = new Regex(pattern);
            //var match = regex.Match(input);
            



            //InitialDataConnection();
            //Read();
            //ReadSelectingColumns();
            //ReadComposingQueries();
            //ReadWithJoin();
            ////Insert();
            ////InsertWithInt32Identity();
            ////InsertSpecificColumn();
            ////Update();
            ////UpdateCombine();
            ////UpdateMutiple();
            ////Delete();
            //BulkCopy();

            //Console.ReadLine();
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
            var ffffffff = DbTstMall.Query<JoinClubOrder>("select * from JoinClubOrder");
            var fffff = DbTstMall.JoinClubOrderIdentity.ToList();
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
