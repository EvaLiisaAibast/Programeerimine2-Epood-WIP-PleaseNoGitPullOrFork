using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReturnLines
{
    public class GetReturnLineQueryHandler : IRequestHandler<GetReturnLineQuery, ReturnLine>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetReturnLineQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ReturnLine> Handle(GetReturnLineQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ReturnLines.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
