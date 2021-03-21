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
    public class UserController : ApiController
    {
        UserRepo _user = new UserRepo();

        [HttpPost]
        [Route("api/user/getUserInfo")]
        public IHttpActionResult getUserInfo()
        {
            return Ok(_user.getUserInfo());
        }
        [HttpPost]
        [Route("api/user/gettableusers")]
        public IHttpActionResult gettableusers(Users.gettableusers tableusers)
        {
            return Ok(_user.gettableusers(tableusers));
        }
        [HttpPost]
        [Route("api/user/getselectusers")]
        public IHttpActionResult getselectusers(Users.getselectedusers selectedusers)
        {
            return Ok(_user.getselectusers(selectedusers));
        }   
        [HttpPost]
        [Route("api/user/updateuser")]
        public IHttpActionResult updateuser(Users.gettableusers updateusers)
        {
            return Ok(_user.updateuser(updateusers));
        }  
        [HttpPost]
        [Route("api/user/insertuser")]
        public IHttpActionResult insertuser(Users.gettableusers insertusers)
        {
            return Ok(_user.insertuser(insertusers));
        }
    }
}
