using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_API.Config;
using WEB_API.Models;
using WEB_API.Models.Constant;

namespace WEB_API.Repository
{
    public class AuthRepository
    {
        public List<UserModel> AuthenticateUser(string username, string password)
        {
            using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    var user_credentials = con.Query<UserModel>($@"SELECT u.`username`,TRIM(p.`modid`) AS 'modid' FROM `userpermission` p
                                JOIN `usermaster` u ON u.`username` = p.`username`  
                                WHERE  p.`modid` = 'ns' AND p.logid = 'login'  AND u.username=@username AND AES_DECRYPT(u.password,u.username) = @password
                                GROUP BY p.modid",
                                new { username = username, password = password }, transaction: tran).ToList();
                    return user_credentials;
                }
            }

        }


    }
}