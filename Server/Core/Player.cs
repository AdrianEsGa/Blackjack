using Shared;

namespace Server.Core;

public class Player
{
    public required string Identifier { get; set; }
    public required PlayerStatus Status { get; set; } = PlayerStatus.Lobby;
    public required int Turn { get; set; }
    public List<PlayCard> Cards { get; set; } = [];
    public GameInfoPoints Points
    {
        get
        {
            return GetPoints();
        }
    }

    public static Player BuildCrupier(Deck deck)
    {
        return new Player
        {
            Identifier = "Crupier",
            Status = PlayerStatus.WaitingTurn,
            Turn = 0,
            Cards = [deck.Draw(isVisible: false), deck.Draw()]
        };
    }

    public void CheckStatus(RoomStatus roomStatus)
    {
        var points = GetPoints(Cards, roomStatus == RoomStatus.Playing);

        if (points > 21)
        {
            Status = PlayerStatus.Lost;
            return;
        }

        Status = PlayerStatus.WaitingTurn;
    }

    private GameInfoPoints GetPoints()
    {
        var visiblePoints = GetPoints(Cards, visibleCards: true);
        var notVisiblePoints = GetPoints(Cards, visibleCards: false);

        return new GameInfoPoints
        {
            VisiblePoints = visiblePoints,
            NotVisiblePoints = notVisiblePoints,
            TotalPoints = visiblePoints + notVisiblePoints
        };
    }

    private static int GetPoints(List<PlayCard> playCards, bool visibleCards = true)
    {
        var cards = playCards.Where(x => x.Visible == visibleCards).Select(x => x.Card).ToList();

        var points = cards.Sum(x => x.Points);

        if (points > 21)
        {
            var aces = cards.Count(x => x.Points == 1);

            while (points > 21 && aces > 0)
            {
                points -= 10;
                aces--;
            }
        }

        return points;
    }
}
