using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;

namespace ComparisonTech.API.Infrastructure
{
    public class AnonymousUserTrackingFilter : IActionFilter
    {
        public const string AnonymousUserCookieKey = "X-Anonymous-UserTracking";
        public const string UserAgent = "User-Agent";
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey(AnonymousUserCookieKey))
            {
                context.HttpContext.Response.Headers.Remove(AnonymousUserTrackingFilter.AnonymousUserCookieKey);
                context.HttpContext.Request.Headers.Add(AnonymousUserCookieKey,
                   new StringValues(Guid.NewGuid().ToString()));
            }
            if (!context.HttpContext.Request.Headers.ContainsKey(AnonymousUserCookieKey))
                context.HttpContext.Request.Headers.Add(AnonymousUserCookieKey,
                    new StringValues(Guid.NewGuid().ToString()));
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey(AnonymousUserCookieKey))
            {
                string trackingId = context.HttpContext.Request.Headers[AnonymousUserCookieKey];
                SetAnonymousHeaderResponse(context.HttpContext.Response, trackingId);
            }
        }

        private static void SetAnonymousHeaderResponse(HttpResponse response, string trackingId)
        {
            response.Headers.Add(AnonymousUserCookieKey, trackingId);
        }
    }
}
