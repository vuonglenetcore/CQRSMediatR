using CQRSMediatR.Data;
using CQRSMediatR.Models;
using CQRSMediatR.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatR.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDatabase _fakeDatabase;

        public GetProductByIdHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDatabase.GetProductById(request.Id);
        }
    }
}