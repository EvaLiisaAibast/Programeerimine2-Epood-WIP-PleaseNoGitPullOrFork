using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WishlistItems
{
    public class DeleteWishlistItemCommandHandler : IRequestHandler<DeleteWishlistItemCommand, OperationResult<bool>>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteWishlistItemCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<bool>> Handle(DeleteWishlistItemCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<bool>();

            if (request.Id <= 0)
            {
                return response.AddError("Id peab olema suurem kui 0.");
            }

            var entity = await _dbContext.WishlistItems.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                return response.AddError("Kirjet ei leitud.");
            }

            _dbContext.WishlistItems.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = true;

            return response;
        }
    }
}
