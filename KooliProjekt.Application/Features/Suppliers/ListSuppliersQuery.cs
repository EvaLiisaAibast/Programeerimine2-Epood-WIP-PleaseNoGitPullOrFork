using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Suppliers
{
    public class ListSuppliersQuery : IRequest<IEnumerable<Supplier>>
    {
    }
}
