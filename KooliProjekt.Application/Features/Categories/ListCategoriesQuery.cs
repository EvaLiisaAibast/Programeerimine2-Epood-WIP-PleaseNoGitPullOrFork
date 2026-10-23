using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Categories
{
    public class ListCategoriesQuery : IRequest<OperationResult<PagedResult<CategoryListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
