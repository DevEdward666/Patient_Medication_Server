using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using WEB_API.Config;
using WEB_API.Models.Constant;

namespace WEB_API.Repository
{
    public class CompanyRepository
    {

        public ResponseModel CompanyName()
        {
            using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    string hospitalName = con.QuerySingleOrDefault<string>(
                        $@"SELECT `GetDefaultValue`('HOSPNAME') AS 'hosp_name'",
                                null, transaction: tran);
                    return new ResponseModel
                    {
                        success = true,
                        data = hospitalName
                    };
                }
            }

        }


        public ResponseModel CompanyLogo()
        {
            using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    byte[] bytes = con.QuerySingleOrDefault<byte[]>(
                        $@"SELECT hosplogo AS 'logo' FROM hospitallogo WHERE hospcode = GetDefaultValue('hospinitial')",
                                null, transaction: tran);
                    return new ResponseModel
                    {
                        success = true,
                        data = "data:image/jpg;base64," + Convert.ToBase64String(bytes)
                    };
                }
            }
        }

        public ResponseModel CompanyTagLine()
        {
            using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    string tagLine = con.QuerySingleOrDefault<string>(
                        $@"SELECT `GetDefaultValue`('HOSPITALTAGLINE') AS 'hosp_tagline'",
                                null, transaction: tran);
                    return new ResponseModel
                    {
                        success = true,
                        data = tagLine
                    };
                }
            }

        }

    }
}