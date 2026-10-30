using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Departments
{
    public class SaveDepartmentCommand : IRequest<OperationResult<int>>
    {
        public DepartmentDto Data { get; set; }
    }
}
