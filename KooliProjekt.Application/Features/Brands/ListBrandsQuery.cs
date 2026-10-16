using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Brands
{
    public class ListBrandsQuery : IRequest<IEnumerable<Brand>>
    {
    }
}
