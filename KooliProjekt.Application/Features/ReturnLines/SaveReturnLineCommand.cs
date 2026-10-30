using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReturnLines
{
    public class SaveReturnLineCommand : IRequest<OperationResult<int>>
    {
        public ReturnLineDto Data { get; set; }
    }
}
