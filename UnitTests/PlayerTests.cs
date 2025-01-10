using FluentAssertions;
using Server.Core;
using Shared;

namespace UnitTests;

public class PlayerTests
{
    [Fact]
    public void Player_Should_Be_Built_As_Crupier()
    {
        var deck = Deck.Build();
        var crupier = Player.BuildCrupier(deck);

        crupier.Identifier.Should().Be("Crupier");
        crupier.Status.Should().Be(PlayerStatus.WaitingTurn);
        crupier.Turn.Should().Be(0);
        crupier.Cards.Count.Should().Be(2);
    }

    [Fact]
    public void Player_Should_Calculate_Points_Correctly()
    {
        var player = new Player
        {
            Identifier = "1",
            Status = PlayerStatus.Playing,
            Turn = 1,
            Cards =
            [
                new PlayCard { Card = new Card { Number = 1, Type = CardType.Hearts }, Visible = true },
                new PlayCard { Card = new Card { Number = 10, Type = CardType.Spades }, Visible = true }
            ]
        };

        var points = player.Points;

        points.VisiblePoints.Should().Be(21);
        points.TotalPoints.Should().Be(21);
    }

    [Fact]
    public void Player_Should_Lose_If_Points_Exceed_21()
    {
        var player = new Player
        {
            Identifier = "1",
            Status = PlayerStatus.Playing,
            Turn = 1,
            Cards =
            [
                new PlayCard { Card = new Card { Number = 10, Type = CardType.Hearts }, Visible = true },
                new PlayCard { Card = new Card { Number = 10, Type = CardType.Spades }, Visible = true },
                new PlayCard { Card = new Card { Number = 5, Type = CardType.Diamonds }, Visible = true }
            ]
        };

        player.CheckStatus(RoomStatus.Playing);

        player.Status.Should().Be(PlayerStatus.Lost);
    }

    [Fact]
    public void Player_Should_Not_Lose_If_Points_Are_21_Or_Less()
    {
        var player = new Player
        {
            Identifier = "1",
            Status = PlayerStatus.Playing,
            Turn = 1,
            Cards =
                [
                    new PlayCard { Card = new Card { Number = 10, Type = CardType.Hearts }, Visible = true },
                    new PlayCard { Card = new Card { Number = 10, Type = CardType.Spades }, Visible = true }
                ]
        };

        player.CheckStatus(RoomStatus.Playing);

        player.Status.Should().Be(PlayerStatus.WaitingTurn);
    }
}
