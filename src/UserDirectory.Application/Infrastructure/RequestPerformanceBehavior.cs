using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UserDirectory.Application.Interfaces.Adapters;

namespace UserDirectory.Application.Infrastructure
{
    public class RequestPerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private const string SlowPerfomanceMessagePattern = "Long Running Request: ({ElapsedMilliseconds} milliseconds) {@Request}";
        private const int AcceptablePerfomanceResult = 500;

        private readonly IStopWatchAdapter stopWatchAdapter;
        private readonly ILogger<TRequest> logger;

        public RequestPerformanceBehavior(IStopWatchAdapter stopWatchAdapter, ILogger<TRequest> logger)
        {
            this.stopWatchAdapter = stopWatchAdapter;
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            stopWatchAdapter.Start();

            TResponse response = await next();

            stopWatchAdapter.Stop();

            if (stopWatchAdapter.ElapsedMilliseconds > AcceptablePerfomanceResult)
            {
                logger.LogWarning(SlowPerfomanceMessagePattern, stopWatchAdapter.ElapsedMilliseconds, request);
            }

            return response;
        }
    }
}