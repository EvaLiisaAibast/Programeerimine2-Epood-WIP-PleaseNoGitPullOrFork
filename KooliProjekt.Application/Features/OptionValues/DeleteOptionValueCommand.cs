using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OptionValues
{
    public class DeleteOptionValueCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
