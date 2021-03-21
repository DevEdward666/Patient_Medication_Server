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
    public class CustomModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var errors =  actionContext.ModelState.Values
        .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage);
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.OK,
                    new
                    {
                        succces = true,
                        errors = errors,
                        message= ""
                    },
                    actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
                );
            }

        }

        //public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        //{
        //    var objectContent = actionExecutedContext.Response.Content as ObjectContent;
        //    if (objectContent != null)
        //    {
        //        var type = objectContent.ObjectType; //type of the returned object
        //        var value = objectContent.Value; //holding the returned value
        //    }
        //}
    }
}