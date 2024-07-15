using Diamond.Services.Validators;

namespace Diamond.Services.UnitTests;

[TestFixture]
public class DiamondRequestValidationTests
{
    private DiamondRequestValidation _diamondRequestValidation;

    [SetUp]
    public void Setup()
    {
        _diamondRequestValidation = new DiamondRequestValidation();
    }

    [Test]
    public void WhenInputIsValid_ShouldReturnTrue()
    {
        // Arrange
        var input = "b";

        // Act
        var result = _diamondRequestValidation.ValidateInput(input);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void WhenInputIsMultipleLetters_ShouldReturnFalse()
    {
        // Arrange
        var input = "be";

        // Act
        var result = _diamondRequestValidation.ValidateInput(input);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void WhenInputIsADigit_ShouldReturnFalse()
    {
        // Arrange
        var input = "2";

        // Act
        var result = _diamondRequestValidation.ValidateInput(input);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void WhenInputIsEmpty_ShouldReturnFalse()
    {
        // Arrange
        var input = " ";

        // Act
        var result = _diamondRequestValidation.ValidateInput(input);

        // Assert
        Assert.That(result, Is.False);
    }
}