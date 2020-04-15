using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class StatusCodeHandler_500 : BaseHandler
{
    protected override void OnProccess(HttpListenerContext httpContext)
    {
        httpContext.Response.ContentLength64 = 0;
        httpContext.Response.StatusCode = 500;
        httpContext.Response.StatusDescription = "Internal Server Error";
    }
}
