using FluentValidation;
using PWSlaba.Models;
using System;
using System.Linq;

namespace PWSlaba.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(0, 10).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(18, 40);
            RuleFor(x => x.Job).Length(4, 30);

        }

    }
}