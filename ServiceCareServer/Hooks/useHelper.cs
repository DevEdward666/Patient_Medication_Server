using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

namespace WEB_API.Hooks
{
    public class useHelper
    {
        public string parserMobileNumber (string mobilenumber)
        {
            if(mobilenumber == null)
            {
                return "";
            }

            try
            {
                string parsed_num =  mobilenumber.Replace("(","").Replace(")", "").Replace("+", "");
                return parsed_num.Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string getPhysicalAddress()
        {
            string physicaladdress = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                                      where nic.OperationalStatus == OperationalStatus.Up
                                      select nic.GetPhysicalAddress().ToString()
                                         ).FirstOrDefault();
            return physicaladdress;
        }
    }
}