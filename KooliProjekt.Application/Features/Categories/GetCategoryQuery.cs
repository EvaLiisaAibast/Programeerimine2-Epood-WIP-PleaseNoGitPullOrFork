using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Categories
{
    public class GetCategoryQuery : IRequest<Category>
    {
        public int Id { get; set; }
    }
}
