using System;
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
    public class AddFileCommandHandler : IRequestHandler<AddFileCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFileClient _fileClient;

        public AddFileCommandHandler(ApplicationDbContext dbContext, IFileClient fileClient)
        {
            _dbContext = dbContext;
            _fileClient = fileClient;
        }

        public async Task<OperationResult<int>> Handle(AddFileCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<int>();

            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (product == null)
            {
                return response.AddError("Toodet ei leitud.");
            }

            var extension = Path.GetExtension(request.FileName).ToLowerInvariant();
            var storedFileName = Guid.NewGuid().ToString("N") + extension;
            var folderName = product.Id.ToString(CultureInfo.InvariantCulture);
            var url = "/files/" + FileStore.ProductImages + "/" + folderName + "/" + storedFileName;

            await _fileClient.Save(storedFileName, FileStore.ProductImages, folderName, request.InputStream);

            var sortOrder = request.SortOrder;

            if (sortOrder <= 0)
            {
                var lastSortOrder = await _dbContext.ProductImages
                    .Where(x => x.ProductId == product.Id)
                    .OrderByDescending(x => x.SortOrder)
                    .Select(x => (int?)x.SortOrder)
                    .FirstOrDefaultAsync(cancellationToken);

                sortOrder = (lastSortOrder ?? 0) + 1;
            }

            if (request.IsMain)
            {
                var currentMainImages = await _dbContext.ProductImages
                    .Where(x => x.ProductId == product.Id && x.IsMain)
                    .ToListAsync(cancellationToken);

                foreach (var currentMainImage in currentMainImages)
                {
                    currentMainImage.IsMain = false;
                }
            }

            var entity = new ProductImage
            {
                ProductId = product.Id,
                Url = url,
                AltText = string.IsNullOrWhiteSpace(request.AltText) ? product.Name : request.AltText,
                SortOrder = sortOrder,
                IsMain = request.IsMain
            };

            _dbContext.ProductImages.Add(entity);

            if (entity.IsMain || string.IsNullOrWhiteSpace(product.ImageUrl))
            {
                entity.IsMain = true;
                product.ImageUrl = url;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
