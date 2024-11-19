namespace Shared;

public class GameInfo
{
    public PlayerStatus Status { get; set; }
    public GameInfoRoom? Room { get; set; }

}

public class GameInfoRoom
{
    public string Indentifier { get; set; } = "";
    public RoomStatus Status { get; set; }
    public GameInfoPlayer Crupier { get; set; } = default!;
    public List<PlayCard> Cards { get; set; } = default!;
    public GameInfoPoints Points { get; set; } = default!;
    public List<GameInfoPlayer> Players { get; set; } = default!;
}

public class GameInfoPlayer
{
    public string Identifier { get; set; } = "";
    public PlayerStatus Status { get; set; }
    public int Turn { get; set; }
    public List<PlayCard> Cards { get; set; } = default!;
    public GameInfoPoints Points { get; set; } = default!;
}

public class GameInfoPoints
{
    public int VisiblePoints { get; set; }
    public int NotVisiblePoints { get; set; }
    public int TotalPoints { get; set; }
}

public enum PlayerStatus
{
    Lobby = 0,
    WaitingTurn = 1,
    Playing = 2,
    Skipped = 3,
    Lost = 4,
    Winner = 5
}

public enum RoomStatus
{
    Playing = 1,
    EndGame = 2
}

