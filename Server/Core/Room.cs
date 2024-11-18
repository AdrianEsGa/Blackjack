﻿using Shared;

namespace Server.Core;

public class Room
{
    public Guid Identifier { get; private set; }
    public List<Player> Players { get; set; } = default!;
    public Player PlayerPlaying { get; set; } = default!;
    public Deck Deck { get; set; } = default!;
    public List<PlayCard> CrupierCards { get; set; } = [];

    public static Room Build()
    {
        var deck = Deck.Build();

        return new Room
        {
            Identifier = Guid.NewGuid(),
            Players = [],
            Deck = deck,
            CrupierCards = [deck.Draw(isVisible: false), deck.Draw()]
        };
    }

    public void AddPlayer(string playerId)
    {
        var turn = Players.Count == 0 ? 1 : Players.Max(x => x.Turn) + 1;

        Players.Add(new Player { Identifier = playerId, Turn = turn, Cards = [Deck.Draw(isVisible: false), Deck.Draw()] });
    }

    public void RemovePlayer(string playerId)
    {
        var player = Players.Single(p => p.Identifier == playerId);

        Deck.Return(player.Cards);

        Players.Remove(player);
    }

    public void NextPlayer()
    {
        PlayerPlaying = GetNext(Players, PlayerPlaying.Turn, p => p.Turn);
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
}