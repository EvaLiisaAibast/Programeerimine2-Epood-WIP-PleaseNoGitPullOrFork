using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Currencies
{
    public class GetCurrencyQuery : IRequest<Currency>
    {
        public int Id { get; set; }
    }
}
