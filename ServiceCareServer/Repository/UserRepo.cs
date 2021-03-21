using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using WEB_API.Config;
using WEB_API.Interface;
using WEB_API.Models.Constant;

namespace WEB_API.Repository
{
    public class UserRepo
    {
        public ResponseModel getUserInfo()
        {
            using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        string username = ((ClaimsIdentity)HttpContext.Current.User.Identity).Name;

                        var data = con.QuerySingle("SELECT um.username,um.empname,ut.`usertype`  FROM usermaster um LEFT JOIN usertype ut ON um.`usertype` = ut.code WHERE um.`username` = @username",
                            new { username = username }, transaction: tran
                            );

                        return new ResponseModel
                        {
                            success = true,
                            data = data
                        };
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
        public ResponseModel getselectusers(Users.getselectedusers selectedusers)
        {
            using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        var data = con.Query($@"SELECT username,empname FROM usermaster WHERE username NOT IN (SELECT username FROM queue_usermaster)",
                           selectedusers, transaction: tran
                            );

                        return new ResponseModel
                        {
                            success = true,
                            data = data
                        };
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
        public ResponseModel gettableusers(Users.gettableusers tableusers)
        {
            using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                  

                    try
                    {
                        var data = con.Query($@"SELECT fullname,username,accnt_type,redirectto,type FROM queue_usermaster",
                           tableusers, transaction: tran
                            );

                        return new ResponseModel
                        {
                            success = true,
                            data = data
                        };
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
        public ResponseModel insertuser(Users.gettableusers insertusers)
        {
            using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    string query = $@"SELECT empname FROM usermaster WHERE username=@username";
                    try
                    {
                        string empname = con.QuerySingle<string>(query, insertusers, transaction: tran);
                        if (empname != null)
                        {

                            int isQueue_UserInserted = con.Execute($@"insert into queue_usermaster (fullname,username,accnt_type,redirectto,type) values('{empname}',@username,@accnt_type,@redirectto,@type)",
                                                  insertusers, transaction: tran);
                            if (isQueue_UserInserted == 1)
                            {

                                tran.Commit();
                                return new ResponseModel
                                {
                                    success = true,
                                    message = "Success! The new user has been added successfully"
                                };
                            }
                            else
                            {
                                return new ResponseModel
                                {
                                    success = false,
                                    message = "Error! No rows affected while inserting the new record."
                                };
                            }
                        }
                        else {
                            return new ResponseModel
                            {
                                success = false,
                                message = "Error! No rows affected while inserting the new record."
                            };
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
        public ResponseModel updateuser(Users.gettableusers updateusers)
        {
            using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        int isQueue_UserInserted = con.Execute($@"update queue_usermaster set fullname=@fullname,accnt_type=@accnt_type,redirectto=@redirectto,type=@type  where username=@username",
                                              updateusers, transaction: tran);
                        if (isQueue_UserInserted == 1)
                        {

                            tran.Commit();
                            return new ResponseModel
                            {
                                success = true,
                                message = "Success! The new user has been updated successfully"
                            };
                        }
                        else
                        {
                            return new ResponseModel
                            {
                                success = false,
                                message = "Error! No rows affected while inserting the new record."
                            };
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

    }
}