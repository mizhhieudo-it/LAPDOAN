using DATNwebtintuc.Models.ModelRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Validator
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(LoginRequest => LoginRequest.Username).Length(1, 30).WithMessage("No more than 20 characters").NotNull().WithMessage("Please enter the username");
            RuleFor(LoginRequest => LoginRequest.password).Length(1, 60).WithMessage("No more than 20 characters").NotNull().WithMessage("Please enter the password");
        }
    }
}