using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WEB_API.Hooks
{
    public class useWaterMarkCreator
    {
        //dbCommon db_common = new dbCommon();
        //public HttpResponseMessage create(string location, string fileName)
        //{
        //    string filePath = HttpContext.Current.Server.MapPath("~") + location + "result.pdf";
        //    byte[] bytes = System.IO.File.ReadAllBytes(filePath);
        //    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1250, true);
        //    BaseColor bc = new BaseColor(0, 0, 0, 75);
        //    Font blackFont = new Font(bfTimes, 70.5F, iTextSharp.text.Font.ITALIC, bc);

        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        PdfReader reader = new PdfReader(bytes);
        //        using (PdfStamper stamper = new PdfStamper(reader, stream))
        //        {
        //            int pages = reader.NumberOfPages;
        //            for (int i = 1; i <= pages; i++)
        //            {
        //                ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(db_common.getEstablishmentName().data.ToString(), blackFont), 245.5F, 480.0F, -55);

        //            }
        //        }
        //        bytes = stream.ToArray();
        //    }

        //    Stream st = new MemoryStream(bytes);

        //    HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StreamContent(st),

        //    };

        //    httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
        //    {
        //        FileName = "resultno" + fileName + ".pdf",
        //    };
        //    httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        //    return httpResponseMessage;

        //}


        //public mdlStream addStamp(string url, string watermarkText)
        //{
        //    try
        //    {
        //        string filePath = HttpContext.Current.Server.MapPath("~") + url;
        //        byte[] bytes = File.ReadAllBytes(filePath);
        //        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1250, true);
        //        BaseColor bc = new BaseColor(0, 0, 0, 75);
        //        Font blackFont = new Font(bfTimes, 70.5F, iTextSharp.text.Font.ITALIC, bc);

        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            PdfReader reader = new PdfReader(bytes);
        //            using (PdfStamper stamper = new PdfStamper(reader, stream))
        //            {
        //                int pages = reader.NumberOfPages;
        //                for (int i = 1; i <= pages; i++)
        //                {
        //                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(watermarkText, blackFont), 245.5F, 480.0F, -55);
        //                }
        //            }
        //            bytes = stream.ToArray();
        //        }

        //        return new mdlStream
        //        {
        //            stream = new MemoryStream(bytes),
        //            success = true
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        return new mdlStream
        //        {
        //            message = e.Message.ToString(),
        //            success = false
        //        };
        //    }
           
        //}


        

    }
}