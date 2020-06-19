using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;

namespace AspNetCoreSample.Middlewares
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cultureIdentifier = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureIdentifier))
            {
                var culture = CultureInfo.GetCultureInfo(cultureIdentifier) ?? CultureInfo.CurrentCulture;

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            await _next(context);
        }

    }
}
