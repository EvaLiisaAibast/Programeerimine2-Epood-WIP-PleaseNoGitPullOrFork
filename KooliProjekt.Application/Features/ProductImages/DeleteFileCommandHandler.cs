using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Files;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, OperationResult<bool>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFileClient _fileClient;

        public DeleteFileCommandHandler(ApplicationDbContext dbContext, IFileClient fileClient)
        {
            _dbContext = dbContext;
            _fileClient = fileClient;
        }

        public async Task<OperationResult<bool>> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<bool>();

            if (request.Id <= 0)
            {
                return response.AddError("Id peab olema suurem kui 0.");
            }

            var entity = await _dbContext.ProductImages.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                return response.AddError("Faili ei leitud.");
            }

            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == entity.ProductId, cancellationToken);

            var nextImage = await _dbContext.ProductImages
                .Where(x => x.ProductId == entity.ProductId && x.Id != entity.Id)
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.Id)
                .FirstOrDefaultAsync(cancellationToken);

            _dbContext.ProductImages.Remove(entity);

            if (product != null && product.ImageUrl == entity.Url)
            {
                product.ImageUrl = nextImage?.Url;
            }

            if (entity.IsMain && nextImage != null)
            {
                nextImage.IsMain = true;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            var fileName = GetFileNameFromUrl(entity.Url);

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                await _fileClient.Delete(fileName, FileStore.ProductImages, entity.ProductId.ToString(CultureInfo.InvariantCulture));
            }

            response.Value = true;

            return response;
        }

        private static string GetFileNameFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            return Path.GetFileName(url.Replace('/', Path.DirectorySeparatorChar));
        }
    }
}
