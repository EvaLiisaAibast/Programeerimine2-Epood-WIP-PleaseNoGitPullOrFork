using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Brands
{
    public class GetBrandQuery : IRequest<OperationResult<BrandDto>>
    {
        public int Id { get; set; }
    }
}
