using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class GetReturnRequestQueryHandler : IRequestHandler<GetReturnRequestQuery, ReturnRequest>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetReturnRequestQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ReturnRequest> Handle(GetReturnRequestQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ReturnRequests.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
