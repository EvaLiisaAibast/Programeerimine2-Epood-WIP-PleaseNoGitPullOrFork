using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Payments
{
    public class DeletePaymentCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
