using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Departments
{
    public class GetDepartmentQuery : IRequest<Department>
    {
        public int Id { get; set; }
    }
}
