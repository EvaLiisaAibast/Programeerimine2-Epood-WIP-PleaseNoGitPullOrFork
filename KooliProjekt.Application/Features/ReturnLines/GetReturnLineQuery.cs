using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReturnLines
{
    public class GetReturnLineQuery : IRequest<OperationResult<ReturnLineDto>>
    {
        public int Id { get; set; }
    }
}
