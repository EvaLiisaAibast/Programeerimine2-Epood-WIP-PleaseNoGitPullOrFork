using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.VariantOptions
{
    public class GetVariantOptionQuery : IRequest<VariantOption>
    {
        public int Id { get; set; }
    }
}
