using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Products
{
    public class ListProductsQuery : IRequest<OperationResult<PagedResult<ProductListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
