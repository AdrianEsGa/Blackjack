namespace Shared;

public class ServerResponse
{
    public required string RequestId { get; set; }
    public required ResponseStatus Status { get; set; }
    public string ErrorMessage { get; set; } = "";
    public GameInfo? GameInfo { get; set; }

    public static ServerResponse Failed(string requestId, string errorMessage)
    {
        return new ServerResponse { RequestId = requestId, Status = ResponseStatus.Error, ErrorMessage = errorMessage };
    }

    public static ServerResponse Success(string requestId, GameInfo gameInfo)
    {
        return new ServerResponse { RequestId = requestId, Status = ResponseStatus.Success, GameInfo = gameInfo };
    }
}

public enum ResponseStatus
{
    Error = 0,
    Success = 1
}

public class GameInfo
{
    public GameStatus Status { get; set; }
    public GameInfoRoom? Room { get; set; }

}

public class GameInfoRoom
{
    public string Indentifier { get; set; } = "";
    public List<PlayCard> CrupierCards { get; set; } = default!;
    public List<PlayCard> Cards { get; set; } = default!;   
    public int Points { get; set; }
    public List<GameInfoPlayer> Players { get; set; } = default!;
}

public class GameInfoPlayer
{
    public string Identifier { get; set; } = "";
    public GameStatus Status { get; set; }
    public int Turn { get; set; }
    public List<PlayCard> Cards { get; set; } = default!;
}

public enum GameStatus
{
    Lobby = 0,
    WaitingTurn = 1,
    Playing = 2,
    Skipped = 3,
    Lost = 4
}