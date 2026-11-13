using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class GetFileCommand : IRequest<OperationResult<ProductFileContentDto>>
    {
        public int Id { get; set; }
    }
}
