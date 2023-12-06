using CQRSMediatR.Data;
using CQRSMediatR.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatR.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddNotification>
    {
        private readonly FakeDatabase _fakeDatabase;

        public EmailHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public async Task Handle(ProductAddNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDatabase.EventOccured(notification.Product, "Event Email sent");
            await Task.CompletedTask;
        }
    }
}