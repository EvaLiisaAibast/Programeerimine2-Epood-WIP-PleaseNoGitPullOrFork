using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.OrderLines
{
    public class GetOrderLineQuery : IRequest<OrderLine>
    {
        public int Id { get; set; }
    }
}
