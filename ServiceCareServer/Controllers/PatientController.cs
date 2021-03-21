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
    public class PatientController : ApiController
    {
    

            PatientsRepo _patients = new PatientsRepo();

            [HttpPost]
            [Route("api/patients/getallmedications")]
            public IHttpActionResult getallmedications(Patients.info info)
            {
                return Ok(_patients.getallmedications(info));
            }

        [HttpPost]
        [Route("api/patients/getspecificmedications")]
        public IHttpActionResult getspecificmedications(Patients.details details)
        {
            return Ok(_patients.getspecificmedications(details));
        }
        [HttpPost]
        [Route("api/patients/patientinformation")]
        public IHttpActionResult patientinformation(Patients.details details)
        {
            return Ok(_patients.patientinformation(details));
        }  
        [HttpPost]
        [Route("api/patients/patientinformationwithoutmeds")]
        public IHttpActionResult patientinformationwithoutmeds(Patients.details details)
        {
            return Ok(_patients.patientinformationwithoutmeds(details));
        }        
        [HttpPost]
        [Route("api/patients/getlogs")]
        public IHttpActionResult getlogs(Patients.users users)
        {
            return Ok(_patients.getlogs(users));
        }      
        [HttpPost]
        [Route("api/patients/getlogsbypatno")]
        public IHttpActionResult getlogsbypatno(Patients.details details)
        {
            return Ok(_patients.getlogsbypatno(details));
        }    
        [HttpPost]
        [Route("api/patients/getlogsbydate")]
        public IHttpActionResult getlogsbydate(Patients.bydate bydate)
        {
            return Ok(_patients.getlogsbydate(bydate));
        }      
        [HttpPost]
        [Route("api/patients/inserttomedicationhistory")]
        public IHttpActionResult inserttomedicationhistory(Patients.details details)
        {
            return Ok(_patients.inserttomedicationhistory(details));
        }

    }
}
