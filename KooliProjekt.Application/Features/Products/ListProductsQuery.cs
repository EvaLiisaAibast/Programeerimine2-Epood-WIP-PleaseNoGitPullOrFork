using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Products
{
    public class ListProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
