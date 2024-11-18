using Shared;

namespace Server.Core;

internal class Engine
{
    private const int _maxRooms = 2;
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
            ActionType.Skip => Skip(request),
            ActionType.OutRoom => OutFromRoom(request),
            ActionType.CheckTurn => CheckTurn(request),
            ActionType.TestConnection => ServerResponse.Success(request.RequestId, new GameInfo { Status = GameStatus.Lobby }), 
            _ => ServerResponse.Failed(request.RequestId, "Invalid action"),
        };
    }

    private ServerResponse CheckTurn(ClientRequest request)
    {
        var room = _rooms.FindRoom(request.RoomId!);

        if (room is null)
            return ServerResponse.Failed(request.RequestId, "Room not found");

        if (room.PlayerPlaying.Identifier == request.PlayerId)      
            return GetResponse(request, GameStatus.Playing, room);
        
        if(room.Players.Count() == 1)
        {
            room.PlayerPlaying = room.Players[0];
            return GetResponse(request, GameStatus.Playing, room);
        }
         
        return GetResponse(request, GameStatus.WaitingTurn, room);
    }

    private ServerResponse Skip(ClientRequest request)
    {
        var room = _rooms.FindRoom(request.RoomId!);

        if (room is null)
            return ServerResponse.Failed(request.RequestId, "Room not found");

        room.NextPlayer();

        return GetResponse(request, GameStatus.WaitingTurn, room);
    }

    private ServerResponse TakeCard(ClientRequest request)
    {
        var room = _rooms.FindRoom(request.RoomId!);

        if (room is null)
            return ServerResponse.Failed(request.RequestId, "Room not found");

        room.Players.Single(p => p.Identifier == request.PlayerId).Cards.Add(room.Deck.Draw());

        room.NextPlayer();

        return GetResponse(request, GameStatus.WaitingTurn, room);
    }

    private ServerResponse OutFromRoom(ClientRequest request)
    {
        var room = _rooms.FindRoom(request.RoomId!);

        if (room is null)
            return ServerResponse.Failed(request.RequestId, "Room not found");

        room.RemovePlayer(request.PlayerId);

        if (room.Players.Count() == 0)
            _rooms.Remove(room);

        return GetResponse(request, GameStatus.Lobby);
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

        var firstPlayer = room.Players.Count() == 1;

        if (firstPlayer)
            room.PlayerPlaying = room.Players[0];

        return GetResponse(request, firstPlayer ? GameStatus.Playing : GameStatus.WaitingTurn, room);
    }

    private ServerResponse GetResponse(ClientRequest request, GameStatus status, Room? room = null)
    {
        return ServerResponse.Success(
            request.RequestId,
            new GameInfo
            {
                Status = status,
                Room = room is null ? null : new GameInfoRoom
                {
                    Indentifier = room.Identifier.ToString(),
                    CrupierCards = room.CrupierCards,
                    Cards = room.Players.Single(x => x.Identifier == request.PlayerId).Cards,
                    Players = room.Players.Where(x => x.Identifier != request.PlayerId)
                                          .Select(p => new GameInfoPlayer { Identifier = p.Identifier, Turn = p.Turn, Cards = p.Cards }).ToList()
                }
            });
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
