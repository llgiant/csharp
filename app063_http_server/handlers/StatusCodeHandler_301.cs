using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class StatusCodeHandler_301 : BaseHandler
{
    private string _location = "";


    public StatusCodeHandler_301(string Location)
    {
        _location = Location;
    }
    protected override void OnProccess(HttpListenerContext httpContext)
    {
        httpContext.Response.AddHeader("Location", _location);
        httpContext.Response.StatusCode = 301;
        httpContext.Response.StatusDescription = "Moved Permanently";
    }


}
