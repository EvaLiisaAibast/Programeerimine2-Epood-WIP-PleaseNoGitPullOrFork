using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Customers
{
    public class SaveCustomerCommand : IRequest<OperationResult<int>>
    {
        public CustomerDto Data { get; set; }
    }
}
