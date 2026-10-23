using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Categories
{
    public class GetCategoryQuery : IRequest<OperationResult<CategoryDto>>
    {
        public int Id { get; set; }
    }
}
