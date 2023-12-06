using CQRSMediatR.Models;
using MediatR;

namespace CQRSMediatR.Notifications
{
    public record ProductAddNotification(Product Product) : INotification();
}