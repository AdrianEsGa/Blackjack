using FluentAssertions;
using Server.Core;
using Shared;

namespace UnitTests;

public class RoomTests
{
    [Fact]
    public void Room_Should_Be_Built_With_Empty_Players_And_Deck()
    {
        Room room = Room.Build();

        room.Identifier.Should().NotBeEmpty();
        room.Players.Should().BeEmpty();
        room.Deck.Cards.Should().NotBeEmpty();
        room.Crupier.Should().NotBeNull();
    }

    [Fact]
    public void Room_Should_Add_Player()
    {
        Room room = Room.Build();
        room.AddPlayer("1");

        room.Players.Count.Should().Be(1);
        room.Players[0].Identifier.Should().Be("1");
        room.Players[0].Cards.Count.Should().Be(2);
    }

    [Fact]
    public void Room_Should_Remove_Player()
    {
        Room room = Room.Build();
        room.AddPlayer("1");
        room.RemovePlayer("1");

        room.Players.Should().BeEmpty();
    }

    [Fact]
    public void Room_Should_Advance_To_Next_Player()
    {
        Room room = Room.Build();
        room.AddPlayer("1");
        room.AddPlayer("2");

        room.PlayerPlaying = room.Players[0];
        room.NextPlayer();

        room.PlayerPlaying.Should().Be(room.Players[1]);
    }

    [Fact]
    public void Room_Should_End_Game_When_No_Players_Waiting()
    {
        Room room = Room.Build();
        room.AddPlayer("1");
        room.Players[0].Status = PlayerStatus.Playing;

        room.NextPlayer();

        room.Status.Should().Be(RoomStatus.EndGame);
    }

    [Fact]
    public void Room_Should_Find_Room_By_Id()
    {
        var rooms = new List<Room> { Room.Build(), Room.Build() };
        var roomId = rooms[0].Identifier.ToString();

        var foundRoom = rooms.FindRoom(roomId);

        foundRoom.Should().NotBeNull();
        foundRoom.Identifier.Should().Be(rooms[0].Identifier);
    }

    [Fact]
    public void Room_Should_Have_Only_One_Player()
    {
        Room room = Room.Build();
        room.AddPlayer("1");

        room.HasOnlyOnePlayer().Should().BeTrue();
    }


}