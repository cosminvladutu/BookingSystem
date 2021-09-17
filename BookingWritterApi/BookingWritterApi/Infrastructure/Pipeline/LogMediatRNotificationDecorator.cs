using MediatR;
using Newtonsoft.Json;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace BookingWritterApi.Infrastructure.Pipeline
{
    public class LogMediatRNotificationDecorator<TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {
        private readonly INotificationHandler<TNotification> _inner;

        public LogMediatRNotificationDecorator(INotificationHandler<TNotification> inner)
        {
            _inner = inner;
        }

        public Task Handle(TNotification notification, CancellationToken cancellationToken)
        {
            Log.Information("Start " + typeof(TNotification).Name);
            var command = JsonConvert.SerializeObject(notification);
            Log.Information($"Request data: {command}");
            return _inner.Handle(notification, cancellationToken);
        }
    }
}
