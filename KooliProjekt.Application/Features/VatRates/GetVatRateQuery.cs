using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.VatRates
{
    public class GetVatRateQuery : IRequest<OperationResult<VatRateDto>>
    {
        public int Id { get; set; }
    }
}
