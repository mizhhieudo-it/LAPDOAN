using DATNwebtintuc.Models.ModelRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Validator
{
    public class PostRequestValidator : AbstractValidator<PostRequest>
    {
        public PostRequestValidator()
        {
            RuleFor(PostRequest => PostRequest.post_title).NotNull().WithMessage("Don't leave it blank");
            RuleFor(PostRequest => PostRequest.post_slug).NotNull().WithMessage("Don't leave it blank");
            RuleFor(PostRequest => PostRequest.post_teaser).NotNull().WithMessage("Don't leave it blank");
            RuleFor(PostRequest => PostRequest.post_tag).NotNull().WithMessage("Don't leave it blank");
            RuleFor(PostRequest => PostRequest.create_date).NotNull().WithMessage("Don't leave it blank");
            RuleFor(PostRequest => PostRequest.edit_date).NotNull().WithMessage("Don't leave it blank");
        }
    }
}