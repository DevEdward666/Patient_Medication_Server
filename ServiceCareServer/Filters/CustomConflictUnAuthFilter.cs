using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WEB_API.Filters
{
    public class CustomConflictUnAuthFilter : ActionFilterAttribute
    {
        //dbUser db_user = new dbUser();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //int allowAccess = db_user.isAllowLogin();
            //if(allowAccess == 0)
            //{
            //    var response = new HttpResponseMessage(HttpStatusCode.Conflict);
            //    response.Content = new StringContent("Simultaneous login in a single station is not allowed. Please ask the previous user in this station to properly logout after cashout.");
            //    actionContext.Response = response;
            //    return;
            //}
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var type = objectContent.ObjectType; //type of the returned object
                var value = objectContent.Value; //holding the returned value
            }
        }
    }
}