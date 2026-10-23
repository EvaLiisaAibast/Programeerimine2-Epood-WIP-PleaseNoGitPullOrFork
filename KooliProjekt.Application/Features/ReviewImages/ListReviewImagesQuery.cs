using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReviewImages
{
    public class ListReviewImagesQuery : IRequest<OperationResult<PagedResult<ReviewImageListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
