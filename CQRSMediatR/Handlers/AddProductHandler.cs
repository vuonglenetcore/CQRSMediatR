using CQRSMediatR.Commands;
using CQRSMediatR.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatR.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly FakeDatabase _fakeDatabase;

        public AddProductHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDatabase.AddProduct(request.Product);

            return Unit.Value;
        }
    }
}