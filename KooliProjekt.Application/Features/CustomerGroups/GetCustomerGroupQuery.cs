using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class GetCustomerGroupQuery : IRequest<CustomerGroup>
    {
        public int Id { get; set; }
    }
}
