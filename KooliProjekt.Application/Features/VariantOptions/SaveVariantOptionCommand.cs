using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.VariantOptions
{
    public class SaveVariantOptionCommand : IRequest<OperationResult<int>>
    {
        public VariantOptionDto Data { get; set; }
    }
}
