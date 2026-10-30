using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Payments
{
    public class SavePaymentCommand : IRequest<OperationResult<int>>
    {
        public PaymentDto Data { get; set; }
    }
}
