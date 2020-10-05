using ComparisonTech.API.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComparisonTech.API.Feature.AnonymousTracking
{
    public class AnonymousTrackingController : ResultController
    {
        [AllowAnonymous]
        [HttpPost("anonymousTracking")]
        [ProducesResponseType(typeof(StatusCodeResult), 201)]
        public ActionResult<AnonymousTrackingResponse> Post()
        {
            var anonymousTrackingId = GetAnonymousUserTrackingId();
            var response = new SuccessResult<AnonymousTrackingResponse>(new AnonymousTrackingResponse(anonymousTrackingId));
            return GetResult(response);
        }
    }
}
