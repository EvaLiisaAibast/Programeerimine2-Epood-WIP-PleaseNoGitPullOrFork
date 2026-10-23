using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Customers
{
    public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, OperationResult<PagedResult<CustomerListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCustomersQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CustomerListItemDto>>> Handle(ListCustomersQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CustomerListItemDto>>();

            response.Value = await _dbContext.Customers
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new CustomerListItemDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
