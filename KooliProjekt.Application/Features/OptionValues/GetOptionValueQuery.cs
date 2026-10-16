using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.OptionValues
{
    public class GetOptionValueQuery : IRequest<OptionValue>
    {
        public int Id { get; set; }
    }
}
