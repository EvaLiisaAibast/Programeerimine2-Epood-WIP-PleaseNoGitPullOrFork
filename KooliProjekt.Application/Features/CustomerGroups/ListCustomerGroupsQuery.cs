using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class ListCustomerGroupsQuery : IRequest<IEnumerable<CustomerGroup>>
    {
    }
}
