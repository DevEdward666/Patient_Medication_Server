using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_API.Hooks
{
    public class useDateParser
    {
        public DateTime toDate(string strDate)
        {
            return strDate == null || strDate.Equals("") ? DateTime.MinValue : Convert.ToDateTime(strDate);
        }

        public DateTime toDateTime(string strDate)
        {
            return DateTime.ParseExact(strDate, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
        }


        public string toYMD(string strDate)
        {
            try
            {
                return Convert.ToDateTime(strDate).ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string toSqlDate(string strDate)
        {
            if(strDate == "")
            {
                return null;
            }

            try
            {
                var zxc = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd");
                return Convert.ToDateTime(strDate).ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string toSqlTime(string strDate)
        {
            try
            {
                return "'" + Convert.ToDateTime(strDate).ToString("hh:mm:ss") + "'";
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string mySQLDate(string str)
        {
            DateTime tempDt = DateTime.MinValue;
            bool valid = true;
            try
            {
                tempDt = Convert.ToDateTime(str);
            }
            catch (Exception)
            {
                valid = false;
            }

            if(valid)
            {
                return tempDt == DateTime.MinValue ? "NULL" : "'" + tempDt.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                return "NULL";
            }
        }

      
    }
}