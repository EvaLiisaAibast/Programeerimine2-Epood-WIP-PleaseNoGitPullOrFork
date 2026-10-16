using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Suppliers
{
    public class GetSupplierQuery : IRequest<Supplier>
    {
        public int Id { get; set; }
    }
}
