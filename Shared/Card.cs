namespace Shared;

public class Card
{
    public CardType Type { get; set; }
    public int Number { get; set; }
    public int Points
    {
        get
        {
            if (Number == 1)
                return 11;

            if (Number > 10)
                return 10;

            return Number;
        }
    }

    public string Name => $"{Value} {TypeIcon}";    

    public string Value => Number switch
    {
        1 => "A",
        11 => "J",
        12 => "Q",
        13 => "K",
        _ => Number.ToString()
    };

    public string TypeIcon => Type switch
    {
        CardType.Hearts => "♥",
        CardType.Diamonds => "♦",
        CardType.Clubs => "♣",
        CardType.Spades => "♠",
        _ => throw new ArgumentOutOfRangeException()
    };

    public string ImageName => $"{Value}_{Type}.png";
}

public enum CardType
{
    Hearts = 1,
    Diamonds = 2,
    Clubs = 3,
    Spades = 4
}