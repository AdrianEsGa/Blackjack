namespace Shared;

public class Card
{
    public CardType Type { get; set; }
    public int Number { get; set; }
    public List<int> Value
    {
        get
        {
            if (Number > 10)
                return [10];

            if (Number == 1)
                return [1, 10];

            return [Number];
        }
    }

    public string Name
    {
        get
        {
            var type = Type switch
            {
                CardType.Hearts => "♥",
                CardType.Diamonds => "♦",
                CardType.Clubs => "♣",
                CardType.Spades => "♠",
                _ => throw new ArgumentOutOfRangeException()
            };

            var value = Number switch
            {
                1 => "A",
                11 => "J",
                12 => "Q",
                13 => "K",
                _ => Number.ToString()
            };

            return $"{value} {type}";
        }
    }

    public string ImageName => $"{Number}_{Type}.png";
}

public enum CardType
{
    Hearts = 1,
    Diamonds = 2,
    Clubs = 3,
    Spades = 4
}