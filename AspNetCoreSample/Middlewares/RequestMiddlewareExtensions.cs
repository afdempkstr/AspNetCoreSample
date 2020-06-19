using Microsoft.AspNetCore.Builder;

namespace AspNetCoreSample.Middlewares
{
    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<RequestCultureMiddleware>();
        }
    }
}
