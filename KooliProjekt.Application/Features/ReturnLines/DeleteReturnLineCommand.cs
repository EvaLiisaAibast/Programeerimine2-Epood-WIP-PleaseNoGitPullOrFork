using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReturnLines
{
    public class DeleteReturnLineCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
