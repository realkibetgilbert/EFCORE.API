using EFCORE.API.Dtos;
using FluentValidation;

namespace EFCORE.API.Helpers.FluentValidation
{
    public class StudentRegistrationValidator : AbstractValidator<StudentToCreateDto>
    {
        public StudentRegistrationValidator()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().MinimumLength(4).Must(IsValidName).WithMessage("{PropertyName}  should be all letters");
            RuleFor(x => x.Email).EmailAddress().WithMessage("{PropertyName} is invalid! Please check!");
            RuleFor(x => x.Password).Equal(z => z.ConfirmPassword).WithMessage("Passwords do not match!!");

        }

        public bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
