using FluentValidation;

namespace BookStore.API.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookModel>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.GenreId).GreaterThan(0);
            RuleFor(command => command.PageCount).GreaterThan(0);
            RuleFor(command => command.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Title).NotEmpty().MinimumLength(4);
        }
    }
}
