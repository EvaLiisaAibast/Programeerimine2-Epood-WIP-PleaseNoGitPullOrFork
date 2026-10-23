using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.VariantOptions
{
    public class GetVariantOptionQuery : IRequest<OperationResult<VariantOptionDto>>
    {
        public int Id { get; set; }
    }
}
