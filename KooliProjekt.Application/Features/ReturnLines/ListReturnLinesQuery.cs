using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReturnLines
{
    public class ListReturnLinesQuery : IRequest<OperationResult<PagedResult<ReturnLineListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
