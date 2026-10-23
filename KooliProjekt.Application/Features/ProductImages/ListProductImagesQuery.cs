using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class ListProductImagesQuery : IRequest<OperationResult<PagedResult<ProductImageListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
