using CQRSMediatR.Models;
using MediatR;
using System.Collections.Generic;

namespace CQRSMediatR.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;
}