using FluentAssertions;
using Server.Core;
using Shared;

namespace UnitTests;

public class ServerEngineTests
{
    [Fact]
    public void Engine_Should_Find_And_Enter_Room()
    {
        var engine = new Engine();
        var player1 = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player1",
            Action = ActionType.FindRoom
        };

        var response = engine.Receive(player1);

        var player2 = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player2",
            Action = ActionType.FindRoom
        };

        var response2 = engine.Receive(player2);

        response.Status.Should().Be(ResponseStatus.Success);
        response.GameInfo.Should().NotBeNull();
        response.GameInfo.Status.Should().Be(PlayerStatus.Playing);
        response.GameInfo.Room.Should().NotBeNull();
        response.GameInfo.Room.Players.Count.Should().Be(0);

        response2.Status.Should().Be(ResponseStatus.Success);
        response2.GameInfo.Should().NotBeNull();
        response2.GameInfo.Status.Should().Be(PlayerStatus.WaitingTurn);
        response2.GameInfo.Room.Should().NotBeNull();
        response2.GameInfo.Room.Players.Count.Should().Be(1);
    }

    [Fact]
    public void Engine_Should_Take_Card()
    {
        var engine = new Engine();
        var roomRequest = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player1",
            Action = ActionType.FindRoom
        };
        var roomResponse = engine.Receive(roomRequest);
        var roomId = roomResponse.GameInfo.Room.Indentifier;

        var request = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player1",
            RoomId = roomId,
            Action = ActionType.TakeCard
        };

        var response = engine.Receive(request);

        response.Status.Should().Be(ResponseStatus.Success);
        response.GameInfo.Should().NotBeNull();
        response.GameInfo.Room.Should().NotBeNull();
        response.GameInfo.Room.Cards.Count.Should().BeGreaterThan(2);
    }

    [Fact]
    public void Engine_Should_Skip_Turn()
    {
        var engine = new Engine();
        var roomRequest = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player1",
            Action = ActionType.FindRoom
        };
        var roomResponse = engine.Receive(roomRequest);
        var roomId = roomResponse.GameInfo.Room.Indentifier;


        var roomRequest2 = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player2",
            Action = ActionType.FindRoom
        };
        var roomResponse2 = engine.Receive(roomRequest2);

        var request = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player1",
            RoomId = roomId,
            Action = ActionType.SkipTurn
        };

        var response = engine.Receive(request);

        response.Status.Should().Be(ResponseStatus.Success);
        response.GameInfo.Should().NotBeNull();
        response.GameInfo.Status.Should().Be(PlayerStatus.Skipped);
    }

    [Fact]
    public void Engine_Should_Out_Room()
    {
        var engine = new Engine();
        var roomRequest = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player1",
            Action = ActionType.FindRoom
        };
        var roomResponse = engine.Receive(roomRequest);
        var roomId = roomResponse.GameInfo.Room.Indentifier;

        var request = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player1",
            RoomId = roomId,
            Action = ActionType.OutRoom
        };

        var response = engine.Receive(request);

        response.Status.Should().Be(ResponseStatus.Success);
        response.GameInfo.Room.Should().BeNull();   
        response.GameInfo.Status.Should().Be(PlayerStatus.Lobby);   
    }

    [Fact]
    public void Engine_Should_Refresh_Game()
    {
        var engine = new Engine();
        var roomRequest = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player1",
            Action = ActionType.FindRoom
        };
        var roomResponse = engine.Receive(roomRequest);
        var roomId = roomResponse.GameInfo.Room.Indentifier;

        var request = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            PlayerId = "Player1",
            RoomId = roomId,
            Action = ActionType.RefreshGame
        };

        var response = engine.Receive(request);

        response.Status.Should().Be(ResponseStatus.Success);
        response.GameInfo.Should().NotBeNull();
        response.GameInfo.Status.Should().Be(PlayerStatus.Playing);
    }

    [Fact]
    public void Engine_Should_Test_Connection()
    {
        var engine = new Engine();
        var request = new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            Action = ActionType.TestConnection
        };

        var response = engine.Receive(request);

        response.Status.Should().Be(ResponseStatus.Success);
        response.GameInfo.Should().NotBeNull();
        response.GameInfo.Status.Should().Be(PlayerStatus.Lobby);
    }

}
