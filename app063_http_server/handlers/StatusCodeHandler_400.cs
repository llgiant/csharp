using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class StatusCodeHandler_400 : BaseHandler
{
    protected override void OnProccess(HttpListenerContext httpContext)
    {
        httpContext.Response.StatusCode = 400;
        httpContext.Response.ContentLength64 = 0;
        httpContext.Response.StatusDescription = "Bad Request";
    }

}
