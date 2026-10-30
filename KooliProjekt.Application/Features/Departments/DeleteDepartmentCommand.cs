using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Departments
{
    public class DeleteDepartmentCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
