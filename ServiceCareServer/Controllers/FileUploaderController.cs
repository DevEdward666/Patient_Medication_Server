using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WEB_API.Controllers
{
    public class FileUploaderController : ApiController
    {
        [HttpPost]
        [Route("api/file/upload")]
        public HttpResponseMessage imageupload()
        {
            var request = HttpContext.Current.Request;
            var description = request.Form["description"];
            var photo = request.Files["photo"];

            string path = HttpContext.Current.Server.MapPath("~/Content/upload/" + description + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                photo.SaveAs(path + photo.FileName);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                photo.SaveAs(path + photo.FileName);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }



        }
    }
}
