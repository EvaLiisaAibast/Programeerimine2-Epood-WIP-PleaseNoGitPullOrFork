using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Refunds
{
    public class SaveRefundCommand : IRequest<OperationResult<int>>
    {
        public RefundDto Data { get; set; }
    }
}
