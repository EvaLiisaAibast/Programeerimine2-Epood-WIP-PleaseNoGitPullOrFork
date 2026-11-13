using FluentValidation;

namespace KooliProjekt.Application.Features.OrderStatusHistories
{
    public class GetOrderStatusHistoryQueryValidator : AbstractValidator<GetOrderStatusHistoryQuery>
    {
        public GetOrderStatusHistoryQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
