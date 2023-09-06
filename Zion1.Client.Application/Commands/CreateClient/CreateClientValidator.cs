
using FluentValidation;
using System.Text.RegularExpressions;

namespace Zion1.Client.Application.Commands.CreateClient;

public class CreateClientValidator : AbstractValidator<CreateClientRequest>
{
    public CreateClientValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.ClientName).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .NotNull()//.WithMessage("Phone Number is required.")
            .MinimumLength(10)//.WithMessage("Phone Number must not be less than 10 characters.")
            .MaximumLength(20)//.WithMessage("Phone Number must not exceed 50 characters.")
            .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("'Phone Number' is invalid");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email is invalid");
    }

}