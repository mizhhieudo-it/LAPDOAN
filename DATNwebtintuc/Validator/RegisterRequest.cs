using DATNwebtintuc.Models.ModelRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Validator
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(RegisterRequest => RegisterRequest.Username).Length(1, 30).WithMessage("No more than 20 characters").NotNull().WithMessage("Don't leave it blank");
            RuleFor(RegisterRequest => RegisterRequest.Email).NotNull().WithMessage("Please enter email");
            RuleFor(RegisterRequest => RegisterRequest.password).Length(1, 60).WithMessage("Don't leave it blank");

        }
    }
}