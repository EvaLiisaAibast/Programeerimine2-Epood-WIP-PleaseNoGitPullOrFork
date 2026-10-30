using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class DeleteEmployeeRoleCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
