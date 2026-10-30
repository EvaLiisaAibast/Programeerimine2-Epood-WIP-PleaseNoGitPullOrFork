using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.VatRates
{
    public class SaveVatRateCommand : IRequest<OperationResult<int>>
    {
        public VatRateDto Data { get; set; }
    }
}
