using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WEB_API.Config
{
    public class DatabaseConfig
    {
        //public static string _dbCon = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
        //public static string _providerEmailAddress = ConfigurationManager.AppSettings["PROVIDER_EMAIL_ADDRESS"];
        //public static string _providerEmailPass = ConfigurationManager.AppSettings["PROVIDER_EMAIL_PASS"];
        //public static string _clientBaseUrl = ConfigurationManager.AppSettings["CLIENT_BASE_URL"];
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
        }

    }
}