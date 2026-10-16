using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.OptionValues
{
    public class ListOptionValuesQueryHandler : IRequestHandler<ListOptionValuesQuery, IEnumerable<OptionValue>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOptionValuesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OptionValue>> Handle(ListOptionValuesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.OptionValues.ToListAsync(cancellationToken);

            return result;
        }
    }
}
