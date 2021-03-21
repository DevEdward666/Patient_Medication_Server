using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Forms;
using WEB_API.Hooks;
using WEB_API.Models.Constant;
using WEB_API.Repository;

namespace WEB_API.Controllers
{

    public class CompanyController : ApiController
    {

        CompanyRepository _company = new CompanyRepository();


        [HttpGet]
        [Route("")]
        public string defaultRoute()
        {
            return "running at 4020";
        }

        [HttpPost]
        [Route("api/company/company-name")]
        public ResponseModel CompanyName()
        {
            return _company.CompanyName();
        }


        [HttpPost]
        [Route("api/company/company-logo")]
        public ResponseModel CompanyLogo()
        {
            return _company.CompanyLogo();
        }

        [HttpPost]
        [Route("api/company/company-tagline")]
        public ResponseModel CompanyTagLine()
        {
            return _company.CompanyTagLine();
        }

    }
}
