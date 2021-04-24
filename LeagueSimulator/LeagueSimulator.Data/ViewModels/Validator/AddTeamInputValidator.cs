using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueSimulator.Data.ViewModels.Validator
{
    public class AddTeamInputValidator:AbstractValidator<AddTeamViewModel>
    {
        public AddTeamInputValidator()
        {
            RuleFor(o => o.TeamName).NotEmpty().NotNull();
            RuleFor(o => o.Attack).NotEmpty().NotNull().GreaterThan(0).LessThan(100);
            RuleFor(o => o.Defense).NotEmpty().NotNull().GreaterThan(0).LessThan(100);
            RuleFor(o => o.Chance).NotEmpty().NotNull().GreaterThan(0).LessThan(100);
            
        }
    }
}
