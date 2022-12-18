using System;
using FluentValidation;

namespace WiseConsulting.Application.Banks.Commands.CreateBank;

public class CreateBankCommandValidator : AbstractValidator<CreateBankCommand>
{
    public CreateBankCommandValidator()
    {
        RuleFor(b => b.Name)
            .MaximumLength(48)
            .NotEmpty();

        RuleFor(b => b.Identifier)
            .Length(3)
            .NotEmpty();
    }
}

