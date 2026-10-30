using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Suppliers
{
    public class DeleteSupplierCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
