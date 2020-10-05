using ComparisonTech.API.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace ComparisonTech.API.Result
{
    [ApiController]
    public abstract class ResultController : ControllerBase
    {
        protected virtual ActionResult<T> GetResult<T>(Result<T> result)
        {
            return StatusCode(result.StatusCode, result.Value);
        }

        protected virtual ActionResult<T> GetErrorResult<T>(Result<T> result)
        {
            return StatusCode(result.StatusCode, new { Error = result.Error, IsSuccessful = result.IsSuccessful, StatusCode = result.StatusCode });
        }

        protected virtual string GetAnonymousUserTrackingId()
        {
            var attribute = ControllerContext.ActionDescriptor.MethodInfo.GetCustomAttribute<AllowAnonymousAttribute>();
            if (attribute == null)
                throw new Exception(
                    "Controller action method must be decorated with attribute 'AllowAnonymous' to be able to retrieve anonymous user tracking id");

            if (Request.Cookies.ContainsKey(AnonymousUserTrackingFilter.AnonymousUserCookieKey))
                return Request.Cookies[AnonymousUserTrackingFilter.AnonymousUserCookieKey];

            if (Request.Headers.ContainsKey(AnonymousUserTrackingFilter.AnonymousUserCookieKey))
                return Request.Headers[AnonymousUserTrackingFilter.AnonymousUserCookieKey];
            return "";
        }
    }
}
