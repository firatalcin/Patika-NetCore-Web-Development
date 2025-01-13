using FluentValidation;

namespace BookStore.API.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookModel>
    {
        public UpdateBookCommandValidator() 
        {
            RuleFor(x => x.id).GreaterThan(0);
            RuleFor(x => x.GenreId).GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().MinimumLength(4);
        }
    }
}
