namespace ExtendingWebApi.DelegatingHandlers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class BasicAuthHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!HasBasicAuth(request)) return Task.FromResult(request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Missing Auth."));

            return base.SendAsync(request, cancellationToken);
        }

        private static bool HasBasicAuth(HttpRequestMessage request)
        {
            return
                !string.IsNullOrWhiteSpace(request.Headers.Authorization?.Scheme) &&
                !string.IsNullOrWhiteSpace(request.Headers.Authorization?.Parameter) &&
                string.Equals(request.Headers.Authorization?.Scheme, "Basic", StringComparison.OrdinalIgnoreCase);

        }
    }
}