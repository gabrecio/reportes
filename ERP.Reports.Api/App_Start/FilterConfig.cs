using ERP.Reports.Api.Models.Responses.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
//using System.Web.Http.Filters;
//using System.Web.Mvc;
//using System.Web.Mvc;

namespace ERP.Reports.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new GlobalExceptionFilter());
        }
    }

    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private const HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

        public override void OnException(HttpActionExecutedContext context)
        {
            List<ErrorDetail> details = new List<ErrorDetail>();
            AddInnerMessage(context.Exception, details);
            var errorResponse = ErrorResponse.Create((int)httpStatusCode, "Internal Server Error", details);

            var response = new HttpResponseMessage(httpStatusCode);
            response.Content = new StringContent(errorResponse.ToString(), Encoding.UTF8, "application/json");
            context.Response = response;
        }


        private void AddInnerMessage(Exception exception, List<ErrorDetail> errorDetails)
        {
            if (exception == null)
                return;
            errorDetails.Add(ErrorDetail.Create(exception.Message));
            if (exception.InnerException != null)
                AddInnerMessage(exception.InnerException, errorDetails);
        }

    }
}
