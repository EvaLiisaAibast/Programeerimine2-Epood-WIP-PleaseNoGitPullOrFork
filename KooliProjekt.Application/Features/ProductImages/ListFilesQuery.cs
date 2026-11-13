using System.Collections.Generic;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class ListFilesQuery : IRequest<OperationResult<IList<ProductFileDto>>>
    {
        public int Id { get; set; }
    }
}
