using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class ListReturnRequestsQuery : IRequest<OperationResult<PagedResult<ReturnRequestListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
