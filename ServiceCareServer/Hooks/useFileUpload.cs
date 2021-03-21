using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using WEB_API.Models.Constant;

namespace WEB_API.Hooks
{
    public static class useFileUpload
    {
        //public mdlResponse UploadFile(HttpRequest httpRequest,string path, int mbSize)
        //{
        //    mdlResponse response = new mdlResponse();
        //    try
        //    {
        //        foreach (string file in httpRequest.Files)
        //        {
        //            string fileUrl = "";
        //            var postedFile = httpRequest.Files[file];

        //            var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
        //            var extension = ext.ToLower();

        //            if (postedFile != null && postedFile.ContentLength > 0)
        //            {
        //                int MaxContentLength = 1024 * 1024 * mbSize; 
        //                //var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));

        //                if (postedFile.ContentLength > MaxContentLength)
        //                {
        //                    response.success = false;
        //                    response.message = string.Format("Error Message: File size  exceeds to the maximum capacity of " + mbSize + "mb.");
        //                }
        //                else
        //                {
        //                    fileUrl = path + DateTime.Now.ToString("yyyyMMddTHHmmssfffffff") + extension;
        //                    var filePath = HttpContext.Current.Server.MapPath(fileUrl);
        //                    postedFile.SaveAs(filePath);

        //                    response.success = true;
        //                    response.message = string.Format("Success Message: The file has been uploaded successfully.");
        //                    response.data = fileUrl;
        //                }
        //            }
        //            return response;
        //        }
        //        response.success = false;
        //        response.message = string.Format("No file detected. Please make sure to select a file to upload.");
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.success = false;
        //        response.message = ex.Message.ToString();
        //        return response;
        //    }
        //}

        public static byte[] base64toByteArray(string base64)
        {
            byte[] bytes = null;
            try
            {
                bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(base64);
            }
            catch (Exception)
            {
                bytes = null;
            }
            return bytes;
        }

        //public bool uploadByteFile(string url, string fileName, byte[] byteFile)
        //{
        //    try
        //    {
        //        string filePath = "~/Uploads/Menus/" + DateTime.Now.ToString("yyyyMMddTHHmmssfffffff") + "test.jpg";
        //        File.WriteAllBytes(HttpContext.Current.Server.MapPath(filePath), byteFile);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in process: {0}", ex);
        //        return false;
        //    }
        //}

        public static ResponseModel uploadeBase64Image(string blob,string path)
        {
            try
            {
                byte[] fileByte = base64toByteArray(blob);

                if (fileByte.Length > 2000000)
                {
                    return new ResponseModel
                    {
                        success = false,
                        message = "The uploaded image exceeds the maximum accepted limit"
                    };
                }
                else
                {
                    var fileUrl = path + DateTime.Now.ToString("yyyyMMddTHHmmssfffffff") + ".jpg";
                    var filePath = HttpContext.Current.Server.MapPath(fileUrl);
                    Image image = new Bitmap(480, UInt16.MaxValue - 36);
                    using (MemoryStream ms = new MemoryStream(fileByte))
                    {
                        image = Image.FromStream(ms);
                        image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    return new ResponseModel
                    {
                        success = true,
                        message = "",
                        data = fileUrl
                    };
                }
            }
            catch (Exception e)
            {
                return new ResponseModel
                {
                    success = false,
                    message = "Some error occured while uploading the image! " + e.Message.ToString()
                };
            }

           }


        public static ResponseModel saveImage(byte[] byteArr, string fileDir)
        {
            try
            {
                if (byteArr.Length > 2000000)
                {
                    return new ResponseModel
                    {
                        success = false,
                        message = "The uploaded image exceeds the maximum accepted limit"
                    };
                }
                else
                {
                    var fileUrl = fileDir + DateTime.Now.ToString("yyyyMMddTHHmmssfffffff") + ".jpg";
                    var filePath = HttpContext.Current.Server.MapPath(fileUrl);
                    Image image = new Bitmap(480, UInt16.MaxValue - 36);
                    using (MemoryStream ms = new MemoryStream(byteArr))
                    {
                        image = Image.FromStream(ms);
                        image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                    }
                    return new ResponseModel
                    {
                        success = true,
                        message = "",
                        data = fileUrl
                    };
                }
            }
            catch (Exception e)
            {
                return new ResponseModel
                {
                    success = false,
                    message = "Some error occured while uploading the image" + e.Message.ToString()
                };
            }


        }


    }
}