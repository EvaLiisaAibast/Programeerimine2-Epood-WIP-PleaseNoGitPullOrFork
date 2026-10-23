using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Currencies
{
    public class GetCurrencyQuery : IRequest<OperationResult<CurrencyDto>>
    {
        public int Id { get; set; }
    }
}
