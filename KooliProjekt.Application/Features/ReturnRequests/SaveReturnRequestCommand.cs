using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class SaveReturnRequestCommand : IRequest<OperationResult<int>>
    {
        public ReturnRequestDto Data { get; set; }
    }
}
