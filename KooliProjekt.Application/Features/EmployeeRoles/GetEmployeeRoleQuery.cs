using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class GetEmployeeRoleQuery : IRequest<EmployeeRole>
    {
        public int Id { get; set; }
    }
}
