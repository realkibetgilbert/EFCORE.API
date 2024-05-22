using EFCORE.API.Dtos;
using FluentValidation;

namespace EFCORE.API.Helpers.FluentValidation
{
    public class StudentRegistrationValidator : AbstractValidator<StudentToCreateDto>
    {
        public StudentRegistrationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Email).EmailAddress().WithMessage("{PropertyName} is invalid! Please check!");
            RuleFor(x => x.Password).Equal(z => z.ConfirmPassword).WithMessage("Passwords do not match!!");

        }
    }
}
