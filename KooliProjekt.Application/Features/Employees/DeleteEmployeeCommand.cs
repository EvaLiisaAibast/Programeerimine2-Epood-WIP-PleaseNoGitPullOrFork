using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Employees
{
    public class DeleteEmployeeCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
