using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class ListCustomerGroupsQueryHandler : IRequestHandler<ListCustomerGroupsQuery, OperationResult<PagedResult<CustomerGroupListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCustomerGroupsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<CustomerGroupListItemDto>>> Handle(ListCustomerGroupsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<CustomerGroupListItemDto>>();

            response.Value = await _dbContext.CustomerGroups
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new CustomerGroupListItemDto
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    DiscountPercent = x.DiscountPercent,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
