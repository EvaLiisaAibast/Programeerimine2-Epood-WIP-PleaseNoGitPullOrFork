using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Refunds
{
    public class GetRefundQuery : IRequest<Refund>
    {
        public int Id { get; set; }
    }
}
