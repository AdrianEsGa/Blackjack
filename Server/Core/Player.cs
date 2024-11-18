using Shared;

namespace Server.Core;

public class Player
{
    public required string Identifier { get; set; }
    public required int Turn { get; set; }
    public List<PlayCard> Cards { get; set; } = [];
}
