using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Departments
{
    public class ListDepartmentsQuery : IRequest<OperationResult<PagedResult<DepartmentListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
