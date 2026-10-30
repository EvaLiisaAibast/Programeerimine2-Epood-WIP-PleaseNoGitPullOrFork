using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class SaveCustomerGroupCommand : IRequest<OperationResult<int>>
    {
        public CustomerGroupDto Data { get; set; }
    }
}
