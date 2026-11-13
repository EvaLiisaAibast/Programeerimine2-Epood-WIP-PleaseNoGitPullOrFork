using System;
using System.IO;
using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class AddFileCommandValidator : AbstractValidator<AddFileCommand>
    {
        private static readonly string[] AllowedExtensions = { ".png", ".jpg", ".jpeg", ".gif", ".webp", ".bmp", ".svg" };

        public AddFileCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.")
                .Custom((id, context) =>
                {
                    var productExists = dbContext.Products.Any(x => x.Id == id);

                    if (!productExists)
                    {
                        context.AddFailure("Id", "Toodet ei leitud.");
                    }
                });

            RuleFor(x => x.FileName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Faili nimi puudub.")
                .Must(HaveAllowedExtension).WithMessage("Lubatud on ainult pildifailid: .png, .jpg, .jpeg, .gif, .webp, .bmp, .svg.");

            RuleFor(x => x.AltText)
                .MaximumLength(200).WithMessage("Alternatiivtekst võib olla kuni 200 tähemärki.");

            RuleFor(x => x.SortOrder)
                .GreaterThanOrEqualTo(0).WithMessage("Järjekord ei tohi olla negatiivne.");

            RuleFor(x => x.InputStream)
                .NotNull().WithMessage("Fail puudub.");
        }

        private static bool HaveAllowedExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName)?.ToLowerInvariant();

            return !string.IsNullOrEmpty(extension) && Array.IndexOf(AllowedExtensions, extension) >= 0;
        }
    }
}
