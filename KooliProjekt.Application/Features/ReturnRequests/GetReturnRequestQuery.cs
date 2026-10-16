using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class GetReturnRequestQuery : IRequest<ReturnRequest>
    {
        public int Id { get; set; }
    }
}
