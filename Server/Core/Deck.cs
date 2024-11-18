using Shared;

namespace Server.Core;

public class Deck
{
    public List<Card> Cards { get; set; } = [];

    public static Deck Build()
    {
        var deck = new Deck();
        deck.Reset();
        deck.Shuffle();
        return deck;
    }

    public void Shuffle()
    {
        Cards = Cards.OrderBy(_ => Guid.NewGuid()).ToList();
    }

    public PlayCard Draw(bool isVisible = true)
    {
        var card = Cards.First();
        Cards.RemoveAt(0);
        return new PlayCard { Card = card, Visible = isVisible};
    }

    public void Return(List<PlayCard> playCards)
    {
        foreach (var playCard in playCards)
        {
            Return(playCard);
        }
    }

    public void Return(PlayCard playCard)
    {
        Cards.Add(playCard.Card);
    }

    public void Reset()
    {
        Cards = [];

        foreach (var type in Enum.GetValues<CardType>())
        {
            for (var i = 1; i <= 13; i++)
            {
                Cards.Add(new Card
                {
                    Type = type,
                    Number = i
                });
            }
        }
    }
}
