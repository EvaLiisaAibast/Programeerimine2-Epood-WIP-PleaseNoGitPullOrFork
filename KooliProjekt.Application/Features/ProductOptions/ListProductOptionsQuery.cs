using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductOptions
{
    public class ListProductOptionsQuery : IRequest<OperationResult<PagedResult<ProductOptionListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
