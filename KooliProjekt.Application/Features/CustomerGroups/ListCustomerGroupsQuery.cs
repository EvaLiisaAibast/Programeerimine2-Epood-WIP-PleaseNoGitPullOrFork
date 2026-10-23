using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class ListCustomerGroupsQuery : IRequest<OperationResult<PagedResult<CustomerGroupListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
