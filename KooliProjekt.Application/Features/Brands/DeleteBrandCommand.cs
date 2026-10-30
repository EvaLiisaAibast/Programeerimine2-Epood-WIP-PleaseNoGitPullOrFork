using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Brands
{
    public class DeleteBrandCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
