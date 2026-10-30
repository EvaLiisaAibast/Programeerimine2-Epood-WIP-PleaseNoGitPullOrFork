using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Employees
{
    public class SaveEmployeeCommand : IRequest<OperationResult<int>>
    {
        public EmployeeDto Data { get; set; }
    }
}
