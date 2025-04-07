using AdPlatformLocator.App.Dtos;
using FluentValidation;

namespace AdPlatformLocator.App.Validators
{
    public class LoadRequestDtoValidator : AbstractValidator<LoadRequestDto>
    {
        public LoadRequestDtoValidator()
        {
            RuleFor(x => x.FilePath)
                .NotEmpty().WithMessage("File path is required.")
                .Must(File.Exists).WithMessage("File does not exist.");
        }
    }
}
