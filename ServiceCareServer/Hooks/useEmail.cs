using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WEB_API.Hooks
{
    public class useEmail
    {

        //public mdlResponse sendEmail(string email, string msg, string subject)
        //{
        //    dbCommon db_global = new dbCommon();
        //    try
        //    {
        //        string establishment_name = db_global.getEstablishmentName().data.ToString();
        //        var fromAddress = new MailAddress(mdlGlobal._providerEmailAddress, establishment_name);
        //        var toAddress = new MailAddress(email, subject);
               
        //        string body = msg;
        //        var smtp = new SmtpClient
        //        {
        //            Host = "smtp.gmail.com",
        //            Port = 587,
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            UseDefaultCredentials = false,
        //            Credentials = new NetworkCredential(fromAddress.Address, mdlGlobal._providerEmailPass)
        //        };
        //        using (var message = new MailMessage(fromAddress, toAddress)
        //        {
        //            Subject = establishment_name + " : "+subject,
        //            Body = body
        //        })
        //        {
        //            smtp.Send(message);
        //        }
        //        return new mdlResponse
        //        {
        //            success = true
        //        };
        //    }
        //    catch (Exception e)
        //    {

        //        return new mdlResponse
        //        {
        //            success = false,
        //            message = $"An error has occured while sending the verification link to the patient. {e.Message.ToString()}"
        //        };
        //    }
        //}


        //public mdlResponse sendEmailAttachment(string email, string msg, string subject,string fileName, Stream streamFile)
        //{
        //    try
        //    {
        //        string establishment_name = db_global.getEstablishmentName().data.ToString();
        //        var fromAddress = new MailAddress(mdlGlobal._providerEmailAddress, establishment_name);
        //        var toAddress = new MailAddress(email, subject);

        //        string body = msg;
        //        var smtp = new SmtpClient
        //        {
        //            Host = "smtp.gmail.com",
        //            Port = 587,
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            UseDefaultCredentials = false,
        //            Credentials = new NetworkCredential(fromAddress.Address, mdlGlobal._providerEmailPass)
        //        };
        //        using (var message = new MailMessage(fromAddress, toAddress)
        //        {
        //            Subject = establishment_name + " : " + subject,
        //            Body = body,

        //            IsBodyHtml = true

        //        }
        //        )
        //        {
        //            message.Attachments.Add(new Attachment(streamFile, fileName + ".pdf"));

        //            smtp.Send(message);
        //        }
        //        return new mdlResponse
        //        {
        //            success = true
        //        };
        //    }
        //    catch (Exception e)
        //    {

        //        return new mdlResponse
        //        {
        //            success = false,
        //            message = $"An error has occured while sending the verification link to the patient. {e.Message.ToString()}"
        //        };
        //    }
        //}

    }
}