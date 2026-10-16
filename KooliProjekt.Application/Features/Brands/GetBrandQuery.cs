using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Brands
{
    public class GetBrandQuery : IRequest<Brand>
    {
        public int Id { get; set; }
    }
}
