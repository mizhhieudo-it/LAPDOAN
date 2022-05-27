using DATNwebtintuc.Models.ModelRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Validator
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(ChangePasswordRequest => ChangePasswordRequest.Email).NotNull().WithMessage("Please enter the email");
            RuleFor(ChangePasswordRequest => ChangePasswordRequest.password).Length(1, 60).WithMessage("No more than 20 characters").NotNull().WithMessage("Please enter the password");
            RuleFor(ChangePasswordRequest => ChangePasswordRequest.oldpassword).Length(1, 60).WithMessage("Vui lòng không nhập quá 20 kí tự").NotNull().WithMessage("Please enter the password old");
        }
    }
}