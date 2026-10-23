using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class GetCustomerGroupQuery : IRequest<OperationResult<CustomerGroupDto>>
    {
        public int Id { get; set; }
    }
}
