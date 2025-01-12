using Shared;

namespace Server.Core;

public class Room
{
    public Guid Identifier { get; private set; }
    public RoomStatus Status { get; set; } = RoomStatus.Playing;
    public List<Player> Players { get; set; } = default!;
    public Player PlayerPlaying { get; set; } = default!;
    public Deck Deck { get; set; } = default!;
    public Player Crupier { get; set; } = default!;

    public static Room Build()
    {
        var deck = Deck.Build();

        return new Room
        {
            Identifier = Guid.NewGuid(),
            Players = [],
            Deck = deck,
            Crupier = Player.BuildCrupier(deck)
        };
    }

    public void AddPlayer(string playerId)
    {
        var turn = Players.Count == 0 ? 1 : Players.Max(x => x.Turn) + 1;

        Players.Add(new Player
        {
            Identifier = playerId,
            Turn = turn,
            Status = PlayerStatus.WaitingTurn,
            Cards = [Deck.Draw(isVisible: false), Deck.Draw()]
        });
    }

    public void RemovePlayer(string playerId)
    {
        var player = Players.Single(p => p.Identifier == playerId);

        Deck.Return(player.Cards);

        Players.Remove(player);
    }

    public void NextPlayer()
    {
        if (Players.Where(x => x.Status == PlayerStatus.WaitingTurn).Any())
            PlayerPlaying = GetNext(Players, PlayerPlaying!.Turn, p => p.Turn);
        else
            Status = RoomStatus.EndGame;
    }

    public void StartNewGame()
    {
        Deck = Deck.Build();    

        Crupier.Cards = [Deck.Draw(isVisible: false), Deck.Draw()];

        foreach(var player in Players)
        {
            player.Cards = [Deck.Draw(isVisible: true), Deck.Draw()];
            player.Status = PlayerStatus.WaitingTurn;
        }

        PlayerPlaying = Players[0];
        Players[0].Status = PlayerStatus.Playing;

        Status = RoomStatus.Playing;   
    }

    public T GetNext<T>(List<T> list, int current, Func<T, int> selector)
    {
        if (list == null || list.Count == 0)
            throw new ArgumentException("The list cannot be null or empty.");

        int currentIndex = list.FindIndex(item => selector(item) == current);

        if (currentIndex == -1)
            throw new ArgumentException("The current ID does not exist in the list.");

        int nextIndex = (currentIndex + 1) % list.Count;

        return list[nextIndex];
    }
}

public static class RoomExtensions
{
    public static Room? FindRoom(this List<Room> rooms, string roomId)
    {
        return rooms.SingleOrDefault(r => r.Identifier.ToString() == roomId);
    }

    public static bool HasOnlyOnePlayer(this Room room) => room.Players.Count == 1;
}