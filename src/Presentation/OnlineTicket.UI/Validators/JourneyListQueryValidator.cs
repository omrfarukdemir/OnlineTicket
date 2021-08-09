using System;
using FluentValidation;
using OnlineTicket.UI.Queries.Models;

namespace OnlineTicket.UI.Validators
{
    public class JourneyListQueryValidator : AbstractValidator<JourneyListQuery>
    {
        public JourneyListQueryValidator()
        {
            RuleFor(x => x.OriginId)
                .Cascade(CascadeMode.Stop)
                .NotEqual(default(int))
                .Must((j, o) => j.DestinationId != o);

            RuleFor(x => x.DestinationId)
                .Cascade(CascadeMode.Stop)
                .NotEqual(default(int));

            RuleFor(x => x.Date)
                .Cascade(CascadeMode.Stop)
                .NotEqual(default(DateTime))
                .GreaterThan(x => DateTime.Now.AddDays(-1));
        }
    }
}