using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Refunds
{
    public class GetRefundQuery : IRequest<OperationResult<RefundDto>>
    {
        public int Id { get; set; }
    }
}
