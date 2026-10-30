using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.VatRates
{
    public class DeleteVatRateCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
