using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Currencies
{
    public class DeleteCurrencyCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
