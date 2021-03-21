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
    public class PatientsRepo
    {
        public ResponseModel getallmedications(Patients.info pat)
        {
            try
            {
                using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        var data = con.Query($@"SELECT pat.patno,inv.`stockdesc`,frq.`freqdesc`,pat.`datestarted`,pat.`status`, CONCAT(doc.`firstname`,' ',doc.`middlename`,' ',doc.`lastname`) doctor FROM patmedication pat JOIN docmaster doc ON doc.`doccode` = pat.`reqdoccode`   JOIN invmaster inv ON inv.`stockcode` = pat.`stockcode` JOIN freqdosage frq ON frq.`freqcode` = pat.`dosecode`  WHERE patno=@patno AND STATUS='A'",
                                                 pat, transaction: tran);
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

        public ResponseModel getspecificmedications(Patients.details details)
        {
            try
            {
                using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        var data = con.Query($@"SELECT DISTINCT ts.patno,td.csno,td.refcode,inv.`stockdesc`,td.`dosedesc` FROM trandtls td JOIN transum ts ON td.csno=ts.csno JOIN patmedication pat ON pat.`patno`=ts.patno   JOIN invmaster inv ON inv.`stockcode`=td.refcode  WHERE td.refcode=@stockcode AND ts.patno=@patno  AND ts.csno=@chargeslip",
                                                 details, transaction: tran);
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
        public ResponseModel patientinformation(Patients.details details)
        {
            try
            {
                using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        var data = con.Query($@"SELECT pat.`patno`,inp.admfirstname,inp.admmiddlename,inp.admlastname,COUNT(inv.`stockdesc`) qty, inv.`stockdesc`,dos.`freqdesc` FROM patmedication pat JOIN invmaster inv ON inv.`stockcode`=pat.`stockcode` JOIN freqdosage dos ON dos.`freqcode`=pat.`dosecode` JOIN inpmaster inp ON inp.patno=pat.patno where pat.patno=@patno AND inv.stockcode=@stock GROUP BY pat.stockcode ORDER BY pat.`patno` ASC",
                                                 details, transaction: tran);
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
        public ResponseModel patientinformationwithoutmeds(Patients.details details)
        {
            try
            {
                using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        var data = con.Query($@"SELECT dt.patno,GetPatientName(dt.patno) patname,vap.sex,vap.`birthdate`,vap.`civilstatus`,SPLIT_STR(vap.`roombedns`, '|', 1) AS roomno,SPLIT_STR(vap.`roombedns`, '|', 2) AS roombedno,SPLIT_STR(vap.`roombedns`, '|', 3) AS nursestation,vap.`complaint`,vap.`admdiagnosis`,vap.`medtype`,vap.`admdate`, GROUP_CONCAT(DISTINCT CONCAT('- ',`GetDoctorsName` (dt.`doccode`))) AS careteam FROM doctortran dt JOIN roomtran rt ON rt.patno = dt.patno JOIN vw_admitted_patients vap ON vap.`patno` = dt.patno WHERE rt.statustag IS NULL AND dt.patno =@patno GROUP BY dt.patno ORDER BY rt.nsunit",
                                                 details, transaction: tran);
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
        public ResponseModel getlogs(Patients.users users)
        {
            try
            {
                using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        string username = ((ClaimsIdentity)HttpContext.Current.User.Identity).Name;
                        var data = con.Query($@"SELECT GetPatientName(pat.`patno`) AS patientname,inv.`stockdesc`,pat.qty,pat.urgency,DATE_FORMAT(pat.givendate,'%Y-%m-%d %H:%m %p') AS givendate FROM patmedicationhistory pat JOIN invmaster inv ON pat.`stockcode`=inv.`stockcode` WHERE pat.user =@user ORDER BY pat.`givendate` DESC limit @limit",
                                                 users, transaction: tran).ToList();
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
        public ResponseModel getlogsbypatno(Patients.details details)
        {
            try
            {
                using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        string username = ((ClaimsIdentity)HttpContext.Current.User.Identity).Name;
                        var data = con.Query($@"SELECT GetPatientName(pat.`patno`) AS patientname,inv.`stockdesc`,pat.qty,pat.urgency,pat.givendate FROM patmedicationhistory pat JOIN invmaster inv ON pat.`stockcode`=inv.`stockcode` WHERE pat.user ='{username}' AND pat.`patno`=@patno",
                                                 details, transaction: tran);
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
        public ResponseModel getlogsbydate(Patients.bydate bydate)
        {
            try
            {
                using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        string username = ((ClaimsIdentity)HttpContext.Current.User.Identity).Name;
                        var data = con.Query($@"SELECT GetPatientName(pat.`patno`) AS patientname,inv.`stockdesc`,pat.qty,pat.urgency,pat.givendate FROM patmedicationhistory pat JOIN invmaster inv ON pat.`stockcode`=inv.`stockcode` WHERE pat.user ='{username}'  AND DATE_FORMAT(pat.givendate,'%Y-%m-%d')  = date_format(@year '" + '-' + "' @month '" + '-' + "' @dayofmonth,'%Y-%m-%d') ",
                                                 bydate, transaction: tran);
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
        public ResponseModel inserttomedicationhistory(Patients.details medicationinsert)
        {
            using (var con = new MySqlConnection(DatabaseConfig.ConnectionString()))
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        string username = ((ClaimsIdentity)HttpContext.Current.User.Identity).Name;

                        int updatejob = con.Execute($@"INSERT INTO patmedicationhistory (stockcode,qty,givendate,urgency,USER,patno)SELECT DISTINCT td.refcode,td.`qty`,NOW(),ts.`urgency`,'{username}',ts.patno FROM trandtls td JOIN transum ts ON td.csno = ts.csno JOIN patmedication pat ON pat.`patno` = ts.patno JOIN invmaster inv ON inv.`stockcode` = td.refcode WHERE td.refcode = @stockcode AND ts.patno =@patno AND ts.csno =@chargeslip ",
                                              medicationinsert, transaction: tran);

                        if (updatejob == 1)
                        {

                            tran.Commit();
                            return new ResponseModel
                            {
                                success = true,
                                message = "The medication has been inserted sucessfully."
                            };

                        }
                        else
                        {
                            return new ResponseModel
                            {
                                success = false,
                                message = "Error! No routine id was generated."
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