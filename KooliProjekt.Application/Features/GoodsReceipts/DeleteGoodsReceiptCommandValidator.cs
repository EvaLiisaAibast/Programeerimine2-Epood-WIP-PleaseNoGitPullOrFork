using FluentValidation;

namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class DeleteGoodsReceiptCommandValidator : AbstractValidator<DeleteGoodsReceiptCommand>
    {
        public DeleteGoodsReceiptCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
