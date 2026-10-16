using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Categories
{
    public class ListCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
