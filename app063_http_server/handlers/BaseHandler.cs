using System;
using System.Net;
using System.IO;


abstract class BaseHandler
{
    protected byte[] Buffer = new byte[] { };  

    public void Proccess(HttpListenerContext httpContext)
    {
        try
        {
            OnProccess(httpContext);
        }
        catch (Exception)
        {

        }

        httpContext.Response.SendChunked = false;
        if (Buffer.Length > 0)
        {
            httpContext.Response.ContentLength64 = Buffer.Length;
            using (BinaryWriter bw = new BinaryWriter(httpContext.Response.OutputStream))
            { bw.Write(Buffer); }
            httpContext.Response.ContentLength64 = Buffer.Length;
            httpContext.Response.StatusCode = 200;
            httpContext.Response.StatusDescription = "Ok";
        }

        PrintResponse(httpContext);
        httpContext.Response.Close();
    }
    protected abstract void OnProccess(HttpListenerContext httpContext);

    public void PrintResponse(HttpListenerContext httpContext)
    {
        Console.WriteLine("{0}:Запрос:{1} Ответ:{2}", Program.GetDate(), httpContext.Request.Url.AbsoluteUri, httpContext.Response.StatusDescription);
    }

}
