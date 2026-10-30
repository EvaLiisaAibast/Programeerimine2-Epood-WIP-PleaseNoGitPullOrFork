using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Currencies
{
    public class SaveCurrencyCommand : IRequest<OperationResult<int>>
    {
        public CurrencyDto Data { get; set; }
    }
}
