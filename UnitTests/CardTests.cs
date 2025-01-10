using Shared;

namespace UnitTests;

public class CardTests
{
    [Fact]
    public void Card_Value_Should_Be_Correct()
    {
        var aceOfSpades = new Card { Type = CardType.Spades, Number = 1 };
        var tenOfHearts = new Card { Type = CardType.Hearts, Number = 10 };
        var jackOfDiamonds = new Card { Type = CardType.Diamonds, Number = 11 };

        Assert.Equal(11, aceOfSpades.Value);
        Assert.Equal(10, tenOfHearts.Value);
        Assert.Equal(10, jackOfDiamonds.Value);
    }

    [Fact]
    public void Card_Name_Should_Be_Correct()
    {
        var aceOfSpades = new Card { Type = CardType.Spades, Number = 1 };
        var tenOfHearts = new Card { Type = CardType.Hearts, Number = 10 };
        var jackOfDiamonds = new Card { Type = CardType.Diamonds, Number = 11 };

        Assert.Equal("A ♠", aceOfSpades.Name);
        Assert.Equal("10 ♥", tenOfHearts.Name);
        Assert.Equal("J ♦", jackOfDiamonds.Name);
    }

    [Fact]
    public void Card_ImageName_Should_Be_Correct()
    {
        var aceOfSpades = new Card { Type = CardType.Spades, Number = 1 };
        var tenOfHearts = new Card { Type = CardType.Hearts, Number = 10 };
        var jackOfDiamonds = new Card { Type = CardType.Diamonds, Number = 11 };

        Assert.Equal("1_Spades.png", aceOfSpades.ImageName);
        Assert.Equal("10_Hearts.png", tenOfHearts.ImageName);
        Assert.Equal("11_Diamonds.png", jackOfDiamonds.ImageName);
    }
}
