using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductVideos
{
    public class ListProductVideosQuery : IRequest<OperationResult<PagedResult<ProductVideoListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
