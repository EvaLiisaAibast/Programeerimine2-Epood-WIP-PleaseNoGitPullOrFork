using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class DeleteCustomerGroupCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
