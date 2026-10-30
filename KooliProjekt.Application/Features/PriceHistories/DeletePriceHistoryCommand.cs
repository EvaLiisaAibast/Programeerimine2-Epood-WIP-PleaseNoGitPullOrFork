using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.PriceHistories
{
    public class DeletePriceHistoryCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
