using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Customers
{
    public class ListCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }
}
