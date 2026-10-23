using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class GetEmployeeRoleQuery : IRequest<OperationResult<EmployeeRoleDto>>
    {
        public int Id { get; set; }
    }
}
