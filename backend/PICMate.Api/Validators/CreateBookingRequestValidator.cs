using FluentValidation;
using PICMate.Api.Domain.Dtos;

namespace PICMate.Api.Validators;

public class CreateBookingRequestValidator : AbstractValidator<CreateBookingRequest>
{
    public CreateBookingRequestValidator()
    {
        RuleFor(x => x.PhotographerId).GreaterThan(0);
        RuleFor(x => x.Service).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Time).NotEmpty();
        RuleFor(x => x.Location).NotEmpty();
        RuleFor(x => x.Total).GreaterThan(0);
    }
}
