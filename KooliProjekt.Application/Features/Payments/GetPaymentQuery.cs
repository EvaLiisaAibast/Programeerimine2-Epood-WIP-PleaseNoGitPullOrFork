using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Payments
{
    public class GetPaymentQuery : IRequest<Payment>
    {
        public int Id { get; set; }
    }
}
