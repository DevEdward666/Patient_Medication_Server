using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_API.Config;
using WEB_API.Interface;
using WEB_API.Models.Constant;

namespace WEB_API.Repository
{
    public class AndroidDefaultsRepo
    {
        public ResponseModel AppDetails(AndroidDefaults.details details)
        {
            try
            {
                using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                      
                        var data = con.Query($@"SELECT * from androidappdefaults where AppName=@AppName",
                                                 details, transaction: tran).ToList();
                        return new ResponseModel
                        {
                            success = true,
                            data = data
                        };
                    }
                }
            }
            catch (Exception e)
            {

                return new ResponseModel
                {
                    success = false,
                    message = $@"External server error. {e.Message.ToString()}",
                };
            }

        }
    }
}