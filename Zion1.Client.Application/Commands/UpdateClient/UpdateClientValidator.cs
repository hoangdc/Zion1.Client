
using FluentValidation;
using System.Text.RegularExpressions;

namespace Zion1.Client.Application.Commands.UpdateClient;

public class UpdateClientValidator : AbstractValidator<UpdateClientRequest>
{
    public UpdateClientValidator()
    {
        RuleFor(x => x.ClientName).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .NotNull().WithMessage("Phone Number is required.")
            .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
            .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");
        RuleFor(x => x.Email).EmailAddress();
    }

}