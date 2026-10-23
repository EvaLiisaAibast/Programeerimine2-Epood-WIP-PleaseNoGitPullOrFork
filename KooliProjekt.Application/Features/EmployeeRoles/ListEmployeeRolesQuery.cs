using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class ListEmployeeRolesQuery : IRequest<OperationResult<PagedResult<EmployeeRoleListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
