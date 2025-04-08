using AdPlatformLocator.App.Dtos;
using AdPlatformLocator.App.Validators;
using FluentValidation.TestHelper;

namespace AdPlatformLocator.Tests.Validation
{
    public class LoadAdPlatformRequestValidatorTests
    {
        private readonly LoadRequestDtoValidator _validator;

        public LoadAdPlatformRequestValidatorTests()
        {
            _validator = new LoadRequestDtoValidator();
        }

        [Fact]
        public void ShouldHaveErrorWhenFilePathIsEmpty() 
        {
            var model = new LoadRequestDto { FilePath = string.Empty };
            
            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.FilePath);
        }

        [Fact]
        public void ShouldHaveErrorWhenFilePathIsInvalid() 
        {
            var model = new LoadRequestDto { FilePath = "Invalid path" };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.FilePath);
        }

        [Fact]
        public void ShouldNotHaveErrorWhenFilePathIsValid()
        {
            var model = new LoadRequestDto { FilePath = "D:\\Programming\\AdPlatformLocator\\Data.txt" };

            var result = _validator.TestValidate(model);
            
            result.ShouldNotHaveValidationErrorFor(x => x.FilePath);
        }

    }
}
