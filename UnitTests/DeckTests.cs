using FluentAssertions;
using Server.Core;

namespace UnitTests;

public class DeckTests
{
    [Fact]
    public void Deck_Should_Have_52_Cards()
    {
        Deck deck = Deck.Build();
        deck.Cards.Count.Should().Be(52);
    }

    [Fact]
    public void Deck_Should_Be_Shuffled()
    {
        Deck deck1 = Deck.Build();
        Deck deck2 = Deck.Build();

        deck1.Cards.Should().NotEqual(deck2.Cards);
    }

    [Fact]
    public void Deck_Should_Draw_Card()
    {
        Deck deck = Deck.Build();
        var initialCount = deck.Cards.Count;

        var playCard = deck.Draw();

        playCard.Should().NotBeNull();
        playCard.Card.Should().NotBeNull();
        deck.Cards.Count.Should().Be(initialCount - 1);
    }

    [Fact]
    public void Deck_Should_Return_Card()
    {
        Deck deck = Deck.Build();
        var playCard = deck.Draw();
        var initialCount = deck.Cards.Count;

        deck.Return(playCard);

        deck.Cards.Count.Should().Be(initialCount + 1);
        deck.Cards.Should().Contain(playCard.Card);
    }

    [Fact]
    public void Deck_Should_Reset()
    {
        Deck deck = Deck.Build();
        deck.Draw();
        deck.Draw();

        deck.Reset();

        deck.Cards.Count.Should().Be(52);
    }
}
