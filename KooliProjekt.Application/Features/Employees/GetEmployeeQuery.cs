using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Employees
{
    public class GetEmployeeQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
