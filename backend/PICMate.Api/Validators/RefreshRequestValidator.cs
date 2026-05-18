using FluentValidation;
using PICMate.Api.Domain.Responses;

namespace PICMate.Api.Validators;

public class RefreshRequestValidator : AbstractValidator<RefreshRequest>
{
    public RefreshRequestValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();
    }
}
