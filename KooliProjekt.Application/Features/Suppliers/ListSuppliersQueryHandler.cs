using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Suppliers
{
    public class ListSuppliersQueryHandler : IRequestHandler<ListSuppliersQuery, OperationResult<PagedResult<SupplierListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListSuppliersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<SupplierListItemDto>>> Handle(ListSuppliersQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<SupplierListItemDto>>();

            response.Value = await _dbContext.Suppliers
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new SupplierListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ContactEmail = x.ContactEmail,
                    Phone = x.Phone,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
