using Diamond.Services;

namespace Diamond.Service.UnitTests;

[TestFixture]
public class DiamondCreationServiceTests
{
    private DiamondCreationService _diamondService;

    [SetUp]
    public void Setup()
    {
        _diamondService = new DiamondCreationService();
    }

    [Test]
    public void WhenInputIsTheCharacterA_ShouldReturnCorrectDiamond()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = _diamondService.CreateDiamond(input);

        // Assert
        Assert.That(result.Length, Is.EqualTo(1));
        Assert.That(result[0], Is.EqualTo("A"));
    }

    [Test]
    public void WhenInputIsTheCharacterC_ShouldReturnCorrectDiamond()
    {
        // Arrange
        var input = 'C';

        // Act
        var result = _diamondService.CreateDiamond(input);

        // Assert
        Assert.That(result.Length, Is.EqualTo(5));
        Assert.That(result[0], Is.EqualTo("  A"));
        Assert.That(result[1], Is.EqualTo(" B B"));
        Assert.That(result[2], Is.EqualTo("C   C"));
        Assert.That(result[3], Is.EqualTo(" B B"));
        Assert.That(result[4], Is.EqualTo("  A"));
    }

    [Test]
    public void WhenInputIsTheCharacterB_ShouldReturnCorrectDiamond()
    {
        // Arrange
        var input = 'M';

        // Act
        var result = _diamondService.CreateDiamond(input);

        // Assert
        Assert.That(result.Length, Is.EqualTo(25));
        Assert.That(result[12], Is.EqualTo("M                       M"));
    }

    [Test]
    public void WhenInputIsTheCharacterZ_ShouldReturnCorrectDiamond()
    {
        // Arrange
        var input = 'Z';

        // Act
        var result = _diamondService.CreateDiamond(input);

        // Assert
        Assert.That(result.Length, Is.EqualTo(51));
        Assert.That(result[25], Is.EqualTo("Z                                                 Z"));
    }
}