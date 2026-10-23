using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Departments
{
    public class GetDepartmentQuery : IRequest<OperationResult<DepartmentDto>>
    {
        public int Id { get; set; }
    }
}
