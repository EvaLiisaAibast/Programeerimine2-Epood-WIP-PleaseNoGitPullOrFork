using System.IO;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class AddFileCommand : IRequest<OperationResult<int>>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string AltText { get; set; }
        public int SortOrder { get; set; }
        public bool IsMain { get; set; }
        public Stream InputStream { get; set; }
    }
}
