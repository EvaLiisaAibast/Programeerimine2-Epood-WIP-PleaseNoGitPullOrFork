using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Suppliers
{
    public class SaveSupplierCommand : IRequest<OperationResult<int>>
    {
        public SupplierDto Data { get; set; }
    }
}
