using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Addresses
{
    public class SaveAddressCommandHandler : IRequestHandler<SaveAddressCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveAddressCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveAddressCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<int>();

            if (request.Data == null)
            {
                return response.AddError("Andmed puuduvad.");
            }

            if (request.Data.Id < 0)
            {
                return response.AddError("Id ei tohi olla negatiivne.");
            }

            Address entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Addresses.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Address();
                _dbContext.Addresses.Add(entity);
            }

            entity.CustomerId = request.Data.CustomerId;
            entity.Country = request.Data.Country;
            entity.City = request.Data.City;
            entity.PostalCode = request.Data.PostalCode;
            entity.Street = request.Data.Street;
            entity.HouseNumber = request.Data.HouseNumber;
            entity.Apartment = request.Data.Apartment;
            entity.IsDefault = request.Data.IsDefault;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
