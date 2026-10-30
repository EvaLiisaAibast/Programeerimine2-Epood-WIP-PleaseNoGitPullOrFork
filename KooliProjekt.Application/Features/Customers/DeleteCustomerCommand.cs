using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Customers
{
    public class DeleteCustomerCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
