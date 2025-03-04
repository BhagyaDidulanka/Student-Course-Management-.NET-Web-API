using FluentValidation;
using Student_Course_Management.DTOs;

namespace Student_Course_Management.Validators
{
    public class StudentValidator : AbstractValidator<StudentDto>
    {
        public StudentValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(s => s.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
