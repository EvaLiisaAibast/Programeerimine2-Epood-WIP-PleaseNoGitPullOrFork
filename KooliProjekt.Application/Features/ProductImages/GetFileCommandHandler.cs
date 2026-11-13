using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class GetFileCommandHandler : IRequestHandler<GetFileCommand, OperationResult<ProductFileContentDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFileClient _fileClient;

        public GetFileCommandHandler(ApplicationDbContext dbContext, IFileClient fileClient)
        {
            _dbContext = dbContext;
            _fileClient = fileClient;
        }

        public async Task<OperationResult<ProductFileContentDto>> Handle(GetFileCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<ProductFileContentDto>();

            if (request.Id <= 0)
            {
                return response.AddError("Id peab olema suurem kui 0.");
            }

            var entity = await _dbContext.ProductImages
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                return response.AddError("Faili ei leitud.");
            }

            var fileName = Path.GetFileName(entity.Url.Replace('/', Path.DirectorySeparatorChar));
            var folderName = entity.ProductId.ToString(CultureInfo.InvariantCulture);

            if (string.IsNullOrWhiteSpace(fileName) ||
                !_fileClient.Exists(fileName, FileStore.ProductImages, folderName))
            {
                return response.AddError("Faili ei leitud.");
            }

            response.Value = new ProductFileContentDto
            {
                Id = entity.Id,
                FileName = fileName,
                ContentType = FileContentTypes.GetContentType(fileName),
                SizeBytes = _fileClient.GetSize(fileName, FileStore.ProductImages, folderName),
                Stream = await _fileClient.Get(fileName, FileStore.ProductImages, folderName)
            };

            return response;
        }
    }
}
