using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.DTOs.Validator
{
    public class AddTeamValidator:AbstractValidator<TeamDTO>
    {
        public AddTeamValidator()
        {
            RuleFor(o => o.Name).NotEmpty().NotNull();
            RuleFor(o => o.Attack).NotEmpty().NotNull().GreaterThan(0).LessThan(100);
            RuleFor(o => o.Defense).NotEmpty().NotNull().GreaterThan(0).LessThan(100);
            RuleFor(o => o.Chance).NotEmpty().NotNull().GreaterThan(0).LessThan(100);
        } 
    }
}
