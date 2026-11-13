using FluentValidation;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class ListFilesQueryValidator : AbstractValidator<ListFilesQuery>
    {
        public ListFilesQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
