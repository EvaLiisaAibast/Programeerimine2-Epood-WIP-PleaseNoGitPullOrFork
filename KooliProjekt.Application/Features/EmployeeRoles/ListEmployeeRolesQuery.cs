using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class ListEmployeeRolesQuery : IRequest<IEnumerable<EmployeeRole>>
    {
    }
}
