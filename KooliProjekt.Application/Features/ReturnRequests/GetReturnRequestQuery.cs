using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class GetReturnRequestQuery : IRequest<OperationResult<ReturnRequestDto>>
    {
        public int Id { get; set; }
    }
}
