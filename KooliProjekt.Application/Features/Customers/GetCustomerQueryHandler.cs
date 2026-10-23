using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Customers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, OperationResult<CustomerDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCustomerQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CustomerDto>();

            response.Value = await _dbContext.Customers
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new CustomerDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                    LastLogin = x.LastLogin,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
