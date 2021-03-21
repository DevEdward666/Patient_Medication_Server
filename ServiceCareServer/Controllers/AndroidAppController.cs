using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_API.Interface;
using WEB_API.Repository;

namespace WEB_API.Controllers
{
    [Authorize(Roles = "login,ns")]
    public class AndroidAppController : ApiController
    {
        AndroidDefaultsRepo _android = new AndroidDefaultsRepo();
        [HttpPost]
        [Route("api/android/getdetails")]
        public IHttpActionResult getappdetails(AndroidDefaults.details details)
        {
            return Ok(_android.AppDetails(details));
        }
    }
}
