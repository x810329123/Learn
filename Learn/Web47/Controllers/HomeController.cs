using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Web47.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            string connectionString = "Server=tcp:malltest.database.windows.net,1433;Initial Catalog=StayfunDbTst;Persist Security Info=False;User ID=_sa;Password=Stayfun9487;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string queryString = @"SELECT TOP (1000) [serialno]
      ,[accountid]
      ,[password]
      ,[primaryemail]
      ,[secondemail]
      ,[isdisabled]
      ,[isactive]
      ,[isaccessbackend]
      ,[activecode]
      ,[authenticationcode]
      ,[deletestatus]
      ,[accountattribute]
      ,[externalid]
      ,[creator]
      ,[createdatetime]
      ,[latestupdater]
      ,[latestupdatedatetime]
      ,[isfirstlogin]
      ,[accounttype]
      ,[ErrorCount]
      ,[IsShowFillInEmail]
      ,[firstlogintime]
      ,[memberLevel]
  FROM [dbo].[Account]";
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                SqlCommand command = new SqlCommand(queryString, connection);
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }

            string temp = dataTable.Rows[0].Field<string>("accountid").ToString();

            string userName = WebConfigurationManager.AppSettings["webpages:Version"];
            ViewBag.Message = $"Your application description page.　　{temp}";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}