using FluentValidation;

namespace KooliProjekt.Application.Features.Notifications
{
    public class GetNotificationQueryValidator : AbstractValidator<GetNotificationQuery>
    {
        public GetNotificationQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
