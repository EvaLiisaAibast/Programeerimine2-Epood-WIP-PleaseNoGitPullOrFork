using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OptionValues
{
    public class ListOptionValuesQuery : IRequest<OperationResult<PagedResult<OptionValueListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
