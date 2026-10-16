using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReturnLines
{
    public class GetReturnLineQuery : IRequest<ReturnLine>
    {
        public int Id { get; set; }
    }
}
