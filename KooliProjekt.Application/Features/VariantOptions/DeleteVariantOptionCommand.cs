using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.VariantOptions
{
    public class DeleteVariantOptionCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
