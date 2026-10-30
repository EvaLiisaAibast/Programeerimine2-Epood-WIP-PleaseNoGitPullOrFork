using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Brands
{
    public class SaveBrandCommand : IRequest<OperationResult<int>>
    {
        public BrandDto Data { get; set; }
    }
}
