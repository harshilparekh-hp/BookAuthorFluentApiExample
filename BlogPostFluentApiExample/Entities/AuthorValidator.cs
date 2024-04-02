using FluentValidation;

namespace BlogPostFluentApiExample.Entities
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName)
                .NotEmpty().WithMessage("Author Name must be present!")
                .Length(5, 50).WithMessage("Author Name should be in the range of 5 to 50");

            RuleFor(x => x.AuthorEmail)
                .NotEmpty().WithMessage("Author Email must be present!")
                .EmailAddress().WithMessage("Email address must be a valid Email");
               

        }

    }
}
