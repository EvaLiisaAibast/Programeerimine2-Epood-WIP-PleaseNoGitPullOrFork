using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Departments
{
    public class ListDepartmentsQuery : IRequest<IEnumerable<Department>>
    {
    }
}
