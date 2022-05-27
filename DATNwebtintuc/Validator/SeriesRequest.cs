using DATNwebtintuc.Models.ModelRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNwebtintuc.Validator
{
    public class SeriesRequestValidator : AbstractValidator<SeriesRequest>
    {
        public SeriesRequestValidator()
        {
            RuleFor(SeriesRequest => SeriesRequest.seriesName).NotNull().WithMessage("Please enter name Series");
        }
    }
}