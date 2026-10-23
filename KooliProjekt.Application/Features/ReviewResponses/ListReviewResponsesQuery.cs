using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class ListReviewResponsesQuery : IRequest<OperationResult<PagedResult<ReviewResponseListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
