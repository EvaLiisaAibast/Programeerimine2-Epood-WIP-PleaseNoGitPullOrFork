using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.VatRates
{
    public class GetVatRateQuery : IRequest<VatRate>
    {
        public int Id { get; set; }
    }
}
