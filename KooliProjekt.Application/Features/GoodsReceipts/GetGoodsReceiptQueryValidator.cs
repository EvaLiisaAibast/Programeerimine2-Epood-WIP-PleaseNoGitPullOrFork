using FluentValidation;

namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class GetGoodsReceiptQueryValidator : AbstractValidator<GetGoodsReceiptQuery>
    {
        public GetGoodsReceiptQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
