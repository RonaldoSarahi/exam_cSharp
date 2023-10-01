using Microsoft.AspNetCore.Http;
using System.Text;

namespace csharp_api.Utils
{
    public static class Util
    {
        public static void SetHttpResponse(HttpContext httpContext, int code, string msg)
        {
            httpContext.Response.StatusCode = code;
            byte[] data = Encoding.UTF8.GetBytes(msg);
            httpContext.Response.Body.Write(data, 0, data.Length);
        }
    }
}
