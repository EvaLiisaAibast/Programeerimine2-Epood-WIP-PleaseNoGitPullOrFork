using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class DeleteReturnRequestCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
