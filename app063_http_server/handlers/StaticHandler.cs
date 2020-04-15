using System;
using System.IO;
using System.Net;

class StaticHandler : BaseHandler
{
    protected override void OnProccess(HttpListenerContext httpContext)
    {
        string path = httpContext.Request.Url.LocalPath.Replace("/", "\\");
        if (path == "\\") { path = "\\index.html"; }
        FileInfo fileInfo = new FileInfo(Program.RootDirectory + path);
        if (!fileInfo.Exists)
        {
            new StatusCodeHandler_404().Proccess(httpContext);
            return;
        }
        //get mime type using extension
        string mime = GetMimeType(fileInfo.Extension);
        if (mime.Length == 0) { new StatusCodeHandler_400(); }

        FileStream fileStream = null;
        try { fileStream = File.OpenRead(fileInfo.FullName); }
        catch (Exception) { new StatusCodeHandler_500().Proccess(httpContext); }//500

        Buffer = new byte[fileStream.Length];
        fileStream.Read(Buffer, 0, (int)fileStream.Length);
        httpContext.Response.ContentType = mime;
    }

    private string GetMimeType(string extension)
    {
        switch (extension)
        {
            case ".ico": return "image/x-icon";
            case ".jpg": return "image/jpeg";
            case ".jpeg": return "image/jpeg";
            case ".png":  return "image/png";
            case ".gif":  return "image/gif";
            case ".css": return "text/css; charset=utf-8";
            case ".js": return "text/js; charset=utf-8";
            case ".html": return "text/html; charset=utf-8";
            case ".mp4": return "video/mp4";
        }
        return string.Empty;
    }
}