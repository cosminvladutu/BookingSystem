using MediatR;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookingReaderApi.Infrastructure.Pipeline
{
    public class MediatrSendPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (next is null)
            {
                throw new ArgumentException("Argument Exception", nameof(next));
            }

            Log.Information("Start " + typeof(TRequest).Name);

            Log.Verbose($"Request data: {request}");
            var response = await next();

            Log.Information("End " + typeof(TRequest).Name);

            return response;
        }
    }
}
