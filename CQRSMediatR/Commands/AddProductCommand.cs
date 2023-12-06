using CQRSMediatR.Models;
using MediatR;

namespace CQRSMediatR.Commands
{
    public record AddProductCommand(Product Product) : IRequest;
}