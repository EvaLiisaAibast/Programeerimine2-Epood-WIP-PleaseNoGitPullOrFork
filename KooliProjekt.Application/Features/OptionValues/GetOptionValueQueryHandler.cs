using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.OptionValues
{
    public class GetOptionValueQueryHandler : IRequestHandler<GetOptionValueQuery, OptionValue>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetOptionValueQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OptionValue> Handle(GetOptionValueQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.OptionValues.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
