using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OptionValues
{
    public class SaveOptionValueCommand : IRequest<OperationResult<int>>
    {
        public OptionValueDto Data { get; set; }
    }
}
