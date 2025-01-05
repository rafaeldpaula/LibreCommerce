using LibreCommerce.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace LibreCommerce.Unit.Domain.Validation;

public class UrlValidatorTests
{
    private readonly UrlValidator _urlValidator;

    public UrlValidatorTests()
    {
        _urlValidator = new UrlValidator();
    }

    [Theory(DisplayName = "Given a Url Image string When validating Then should validate according to UriFormat")]
    [InlineData("http://www.test.com", true)]
    [InlineData("https://www.test.com", true)]
    [InlineData("ftp://www.test.com", true)]
    [InlineData("www.test.com", false)]
    [InlineData("test.com", false)]
    [InlineData(".com", false)]
    [InlineData("", false)]
    [InlineData("test", false)]
    public void Given_ValidUrlImage_When_Validating_Then_ShouldValidateAccordingToPattern(string url, bool expectedResult)
    {
        var result = _urlValidator.Validate(url);

        result.IsValid.Should().Be(expectedResult);
    }
}