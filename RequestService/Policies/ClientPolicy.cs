using Polly;
using Polly.Retry;

namespace RequestService.Policies
{
    public class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> ImmidiateHttpPolicy { get; }
        public AsyncRetryPolicy<HttpResponseMessage> LinearHttpPolicy { get; }

        public ClientPolicy()
        {
            ImmidiateHttpPolicy = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode).RetryAsync(5);

            LinearHttpPolicy = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode).WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(3));

        }
    }
}
