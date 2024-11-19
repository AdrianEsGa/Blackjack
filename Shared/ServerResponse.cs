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
