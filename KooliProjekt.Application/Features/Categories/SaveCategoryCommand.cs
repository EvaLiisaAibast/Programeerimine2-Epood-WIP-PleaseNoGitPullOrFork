using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Categories
{
    public class SaveCategoryCommand : IRequest<OperationResult<int>>
    {
        public CategoryDto Data { get; set; }
    }
}
