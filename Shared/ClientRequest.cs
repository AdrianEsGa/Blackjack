namespace Shared;

public class ClientRequest
{
    public required string RequestId { get; set; }
    public string PlayerId { get; set; } = "";
    public string? RoomId { get; set; }  
    public required ActionType Action { get; set; }
}
