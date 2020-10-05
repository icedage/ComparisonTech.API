namespace ComparisonTech.API.Feature.AnonymousTracking
{
    public class AnonymousTrackingResponse
    {
        public AnonymousTrackingResponse(string anonymousTrackingId)
        {
            AnonymousTrackingId = anonymousTrackingId;
        }

        public string AnonymousTrackingId { get; private set; }
    }
}
