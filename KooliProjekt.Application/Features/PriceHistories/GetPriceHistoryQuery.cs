using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.PriceHistories
{
    public class GetPriceHistoryQuery : IRequest<OperationResult<PriceHistoryDto>>
    {
        public int Id { get; set; }
    }
}
