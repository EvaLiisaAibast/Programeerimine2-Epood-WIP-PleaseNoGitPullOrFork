using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
    public class ListFilesQueryHandler : IRequestHandler<ListFilesQuery, OperationResult<IList<ProductFileDto>>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFileClient _fileClient;

        public ListFilesQueryHandler(ApplicationDbContext dbContext, IFileClient fileClient)
        {
            _dbContext = dbContext;
            _fileClient = fileClient;
        }

        public async Task<OperationResult<IList<ProductFileDto>>> Handle(ListFilesQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<IList<ProductFileDto>>();

            var productExists = await _dbContext.Products
                .AsNoTracking()
                .AnyAsync(x => x.Id == request.Id, cancellationToken);

            if (!productExists)
            {
                return response.AddError("Toodet ei leitud.");
            }

            var images = await _dbContext.ProductImages
                .AsNoTracking()
                .Where(x => x.ProductId == request.Id)
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.Id)
                .ToListAsync(cancellationToken);

            var files = new List<ProductFileDto>();

            foreach (var image in images)
            {
                var fileName = Path.GetFileName(image.Url.Replace('/', Path.DirectorySeparatorChar));
                var folderName = image.ProductId.ToString(CultureInfo.InvariantCulture);
                var fileExists = !string.IsNullOrWhiteSpace(fileName) &&
                                 _fileClient.Exists(fileName, FileStore.ProductImages, folderName);

                files.Add(new ProductFileDto
                {
                    Id = image.Id,
                    ProductId = image.ProductId,
                    FileName = fileName,
                    Url = image.Url,
                    ContentType = string.IsNullOrWhiteSpace(fileName) ? null : FileContentTypes.GetContentType(fileName),
                    SizeBytes = fileExists ? _fileClient.GetSize(fileName, FileStore.ProductImages, folderName) : 0,
                    FileExists = fileExists,
                    AltText = image.AltText,
                    SortOrder = image.SortOrder,
                    IsMain = image.IsMain
                });
            }

            response.Value = files;

            return response;
        }
    }
}
