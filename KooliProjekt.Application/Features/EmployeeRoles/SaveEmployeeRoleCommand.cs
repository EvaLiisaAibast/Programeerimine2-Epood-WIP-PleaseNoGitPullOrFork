using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class SaveEmployeeRoleCommand : IRequest<OperationResult<int>>
    {
        public EmployeeRoleDto Data { get; set; }
    }
}
