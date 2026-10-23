using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OptionValues
{
    public class GetOptionValueQuery : IRequest<OperationResult<OptionValueDto>>
    {
        public int Id { get; set; }
    }
}
