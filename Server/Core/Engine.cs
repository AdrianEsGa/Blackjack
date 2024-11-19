using Shared;

namespace Server.Core;

internal class Engine
{
    private const int _maxRooms = 1;
    private const int _maxPlayersPerRoom = 3;

    private List<Room> _rooms;

    public Engine()
    {
        _rooms = [];
    }

    public ServerResponse Receive(ClientRequest request)
    {
        return request.Action switch
        {
            ActionType.FindRoom => FindAndEnterRoom(request),
            ActionType.TakeCard => TakeCard(request),
            ActionType.SkipTurn => SkipTurn(request),
            ActionType.OutRoom => OutRoom(request),
            ActionType.RefreshGame => RefreshGame(request),
            ActionType.TestConnection => ServerResponse.Success(request.RequestId, new GameInfo { Status = PlayerStatus.Lobby }),
            _ => ServerResponse.Failed(request.RequestId, "Invalid action"),
        };
    }

    private ServerResponse RefreshGame(ClientRequest request)
    {
        var room = _rooms.FindRoom(request.RoomId!);

        if (room is null)
            return ServerResponse.Failed(request.RequestId, "Room not found");

        if (room.Status == RoomStatus.EndGame)
            return GetResponse(request, room);

        var player = room.Players.Single(p => p.Identifier == request.PlayerId);

        if (room.PlayerPlaying.Identifier == player.Identifier)
        {
            player.Status = PlayerStatus.Playing;
            return GetResponse(request, room);
        }

        if (room.HasOnlyOnePlayer())
        {
            player.Status = PlayerStatus.Playing;
            room.PlayerPlaying = player;
            return GetResponse(request, room);
        }

        return GetResponse(request, room);
    }

    private ServerResponse SkipTurn(ClientRequest request)
    {
        var room = _rooms.FindRoom(request.RoomId!);

        if (room is null)
            return ServerResponse.Failed(request.RequestId, "Room not found");

        if (room.Status == RoomStatus.EndGame)
            return GetResponse(request, room);

        var player = room.Players.Single(p => p.Identifier == request.PlayerId);

        player.Status = PlayerStatus.Skipped;

        MoveToNextPlayer(room);

        return GetResponse(request, room);
    }

    private ServerResponse TakeCard(ClientRequest request)
    {
        var room = _rooms.FindRoom(request.RoomId!);

        if (room is null)
            return ServerResponse.Failed(request.RequestId, "Room not found");

        if (room.Status == RoomStatus.EndGame)
            return GetResponse(request, room);

        var player = room.Players.Single(p => p.Identifier == request.PlayerId);

        player.Cards.Add(room.Deck.Draw());

        player.CheckStatus(room.Status);

        MoveToNextPlayer(room);

        return GetResponse(request, room);
    }

    private ServerResponse OutRoom(ClientRequest request)
    {
        var room = _rooms.FindRoom(request.RoomId!);

        if (room is null)
            return ServerResponse.Failed(request.RequestId, "Room not found");

        room.RemovePlayer(request.PlayerId);

        if (room.Players.Count() == 0)
            _rooms.Remove(room);

        return GetResponse(request);
    }

    private ServerResponse FindAndEnterRoom(ClientRequest request)
    {
        var room = _rooms.FirstOrDefault(r => r.Players.Count() < _maxPlayersPerRoom);

        if (room is null && _rooms.Count >= _maxRooms)
            return ServerResponse.Failed(request.RequestId, "Sorry, all the rooms are full ...");

        if (room is null)
        {
            room = Room.Build();
            _rooms.Add(room);
        }

        room.AddPlayer(request.PlayerId);

        if (room.HasOnlyOnePlayer())
        {
            room.PlayerPlaying = room.Players[0];
            room.Players[0].Status = PlayerStatus.Playing;
        }

        return GetResponse(request, room);
    }

    private void MoveToNextPlayer(Room room)
    {
        room.NextPlayer();

        if (room.Status == RoomStatus.EndGame)
        {
            MakeAllCardsVisibles(room);
            CheckWinner(room);
        }
    }

    private void CheckWinner(Room room)
    {
        var activePlayers = room.Players.Where(x => x.Status == PlayerStatus.Skipped);

        if (activePlayers.Any())
        {
            //the players with more than 21 points lose
            var crupierPoints = room.Crupier.Points.TotalPoints;

            foreach (var player in activePlayers)
            {
                var points = player.Points.TotalPoints;

                if (points > 21)
                    player.Status = PlayerStatus.Lost;
            }

            //the players with less points than the crupier lose, and the players with more points win
            activePlayers = room.Players.Where(x => x.Status == PlayerStatus.Skipped).ToList();

            if (activePlayers.Any())
            {
                foreach (var player in activePlayers)
                {
                    var points = player.Points.TotalPoints;

                    if (points > crupierPoints)
                        player.Status = PlayerStatus.Winner;
                    else
                        player.Status = PlayerStatus.Lost;
                }
            }

            //if there are more than one winners, the one with more points wins
            var winners = room.Players.Where(x => x.Status == PlayerStatus.Winner).ToList();

            if (winners.Count() > 1)
            {
                var winner = winners.OrderByDescending(x => x.Points.TotalPoints).First();
                winner.Status = PlayerStatus.Winner;

                foreach (var player in winners.Where(x => x.Identifier != winner.Identifier))
                {
                    player.Status = PlayerStatus.Lost;
                }
            }
        }

        //if there are no winners, the crupier wins
        if (!room.Players.Any(x => x.Status == PlayerStatus.Winner))
        {
            room.Crupier.Status = PlayerStatus.Winner;
        }
        else room.Crupier.Status = PlayerStatus.Lost;
    }

    private static void MakeAllCardsVisibles(Room room)
    {
        foreach (var player in room.Players)
        {
            foreach (var notVisibleCard in player.Cards.Where(x => !x.Visible))
            {
                notVisibleCard.Visible = true;
            }
        }
    }

    private ServerResponse GetResponse(ClientRequest request, Room? room = null)
    {
        var player = room?.Players.SingleOrDefault(x => x.Identifier == request.PlayerId);
        var crupier = room?.Crupier;

        return ServerResponse.Success(
            request.RequestId,
            new GameInfo
            {
                Status = player is null ? PlayerStatus.Lobby : player.Status,
                Room = room is null ? null : new GameInfoRoom
                {
                    Indentifier = room.Identifier.ToString(),
                    Crupier = new GameInfoPlayer
                    {
                        Identifier = crupier!.Identifier,
                        Cards = crupier.Cards,
                        Status = crupier.Status,
                        Points = crupier.Points
                    },
                    Cards = player!.Cards,
                    Points = player.Points,
                    Players = room.Players.Where(x => x.Identifier != request.PlayerId)
                                          .Select(p => new GameInfoPlayer
                                          {
                                              Identifier = p.Identifier,
                                              Turn = p.Turn,
                                              Cards = p.Cards,
                                              Status = p.Status,
                                              Points = p.Points
                                          }).ToList()
                }
            });
    }
}