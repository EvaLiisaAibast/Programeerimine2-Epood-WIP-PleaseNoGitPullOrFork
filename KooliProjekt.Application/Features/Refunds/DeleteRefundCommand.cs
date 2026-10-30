using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Refunds
{
    public class DeleteRefundCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
