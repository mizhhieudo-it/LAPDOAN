using DATNwebtintuc.Models.ModelRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Validator
{
    public class TagsRequestValidator : AbstractValidator<TagsRequest>
    {
        public TagsRequestValidator() 
        {
            RuleFor(CategoryRequest => CategoryRequest.TagName).NotNull().WithMessage("Please enter name Tags");
        }
    }
}