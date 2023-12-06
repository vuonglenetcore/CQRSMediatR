using CQRSMediatR.Models;
using MediatR;

namespace CQRSMediatR.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}