using Polly;
using Polly.Retry;

namespace RequestService.Policies
{
    public class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> ImmidiateHttpPolicy { get; }

        public ClientPolicy()
        {
            ImmidiateHttpPolicy =Policy.HandleResult<HttpResponseMessage>(
                res=> !res.IsSuccessStatusCode).RetryAsync(5);
        }
    }
}
