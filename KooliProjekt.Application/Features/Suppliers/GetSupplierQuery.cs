using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Suppliers
{
    public class GetSupplierQuery : IRequest<OperationResult<SupplierDto>>
    {
        public int Id { get; set; }
    }
}
