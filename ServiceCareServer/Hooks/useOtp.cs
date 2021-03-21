using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_API.Hooks
{
    public class useOtp
    {
        public  string createOTP()
        {
            string num = "0123456789";
            int len = num.Length;
            string otp = "";
            int otpSize = 6;
            string finalDigit;
            int getIndex;

            for (int i = 0; i < otpSize; i++)
            {
                do
                {
                    getIndex = new Random().Next(0, len);
                    finalDigit = num.ToCharArray()[getIndex].ToString();
                } while (otp.IndexOf(finalDigit) != -1);
                otp += finalDigit;
            }
            return otp;
        }
    }
}