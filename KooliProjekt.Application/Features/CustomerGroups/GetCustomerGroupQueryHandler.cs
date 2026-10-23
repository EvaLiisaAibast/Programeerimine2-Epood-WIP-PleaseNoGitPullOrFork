using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class GetCustomerGroupQueryHandler : IRequestHandler<GetCustomerGroupQuery, OperationResult<CustomerGroupDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCustomerGroupQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CustomerGroupDto>> Handle(GetCustomerGroupQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CustomerGroupDto>();

            response.Value = await _dbContext.CustomerGroups
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new CustomerGroupDto
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    DiscountPercent = x.DiscountPercent,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
