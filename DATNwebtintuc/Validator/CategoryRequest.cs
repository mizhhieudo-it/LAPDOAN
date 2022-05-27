using DATNwebtintuc.Models.ModelRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Validator
{
    public class CategoryRequestValidator : AbstractValidator<CategoryRequest>
    {
        public CategoryRequestValidator() 
        {
            RuleFor(CategoryRequest => CategoryRequest.namecategory).NotNull().WithMessage("Please enter name category");
        }
    }
}