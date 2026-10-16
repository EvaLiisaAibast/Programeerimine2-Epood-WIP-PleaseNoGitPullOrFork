using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Carriers
{
    public class GetCarrierQuery : IRequest<Carrier>
    {
        public int Id { get; set; }
    }
}
