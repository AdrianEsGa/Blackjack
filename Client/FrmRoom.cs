using Client.Core;
using Shared;

namespace Client;

public partial class FrmRoom : Form
{
    private Engine _engine;
    private Guid _playerId;
    private readonly string _resourcePath = @$"{Application.StartupPath}/Resources/Images/";

    public FrmRoom(Guid playerId)
    {
        InitializeComponent();
        _playerId = playerId;
        lblPlayerId.Text = $"Player: {playerId}";
        _engine = new Engine(playerId);
    }

    private void FrmRoom_Load(object sender, EventArgs e)
    {
        _engine.FindRoom();

        RefreshScreen();
    }

    private void btnFindRoom_Click(object sender, EventArgs e)
    {
        _engine.FindRoom();
        RefreshScreen();
    }

    private void btnOutRoom_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnTakeCard_Click(object sender, EventArgs e)
    {
        _engine.TakeCard();
        RefreshScreen();
    }

    private void btnSkip_Click(object sender, EventArgs e)
    {
        _engine.Skip();
        RefreshScreen();
    }

    private void timerCheckTurn_Tick(object sender, EventArgs e)
    {
        _engine.CheckTurn();
        RefreshScreen();
    }

    private void btnNewPlayer_Click(object sender, EventArgs e)
    {
        FrmRoom form = new FrmRoom(_playerId);
        form.Show();
    }

    private void FrmRoom_FormClosing(object sender, FormClosingEventArgs e)
    {
        _engine.OutRoom();
    }

    private void RefreshScreen()
    {
        if (!_engine.IsInRoom()) return;

        var room = _engine.GetGameInfo().Room!;

        Text = _engine.IsInRoom() ? $"Room {room.Indentifier}" : "Lobby";

        btnOutRoom.Enabled = _engine.IsInRoom();
        btnTakeCard.Enabled = _engine.IsPlaying();
        btnSkip.Enabled = _engine.IsPlaying();

        lblGameStatus.Text = room.Status == RoomStatus.Playing ? "Playing" : "End game";

        ShowCards();
        ShowCurrentTurn();
        ShowPoints();

        if (room.Status == RoomStatus.EndGame)
            _engine.StartNewGame();
    }

    private void ShowPoints()
    {
        // throw new NotImplementedException();
    }

    private void ShowCurrentTurn()
    {
        var room = _engine.GetGameInfo().Room!;

        var playerPlaying = room.PlayerPlaying;

        foreach (Control control in Controls)
        {
            if (control is FlowLayoutPanel flp && flp.Tag != null)
            {
                if (flp.Tag.ToString() == playerPlaying.Identifier)
                    flp.BackColor = Color.Green;
                else flp.BackColor = Color.Transparent;
            }
        }
    }

    private void ShowCards()
    {
        var room = _engine.GetGameInfo().Room!;

        ShowCrupierCards(room);

        ShowMyCards(room);

        ShowOtherPlayersCards(room);
    }

    private void ShowCrupierCards(GameInfoRoom room)
    {
        flwCrupier.Controls.Clear();
        foreach (var card in room.Crupier.Cards)
        {
            flwCrupier.Controls.Add(new PictureBox
            {
                Image = Image.FromFile($@"{_resourcePath}{card.Card.ImageName}"),
                Size = new Size(136, 167),
                SizeMode = PictureBoxSizeMode.Zoom
            });
        }
    }

    private void ShowOtherPlayersCards(GameInfoRoom room)
    {
        if (room.Players.Count >= 1)
        {
            if (flwPlayer2.Controls.Count != room.Players[0].Cards.Count)
            {
                flwPlayer2.Controls.Clear();
                foreach (var card in room.Players[0].Cards)
                {
                    flwPlayer2.Controls.Add(new PictureBox
                    {
                        Image = Image.FromFile($@"{_resourcePath}{card.Card.ImageName}"),
                        Size = new Size(136, 167),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(-5)
                    });
                }
                flwPlayer2.Tag = room.Players[0].Identifier;
            }
        }
        else
        {
            flwPlayer2.Controls.Clear();
            flwPlayer2.Tag = null;
        }

        if (room.Players.Count >= 2)
        {
            if (flwPlayer3.Controls.Count != room.Players[1].Cards.Count)
            {
                flwPlayer3.Controls.Clear();
                foreach (var card in room.Players[1].Cards)
                {
                    flwPlayer3.Controls.Add(new PictureBox
                    {
                        Image = Image.FromFile($@"{_resourcePath}{card.Card.ImageName}"),
                        Size = new Size(136, 167),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(-5)
                    });
                }
                flwPlayer3.Tag = room.Players[1].Identifier;
            }
        }
        else
        {
            flwPlayer3.Controls.Clear();
            flwPlayer3.Tag = null;
        }

        if (room.Players.Count == 3)
        {
            if (flwPlayer4.Controls.Count != room.Players[2].Cards.Count)
            {
                flwPlayer4.Controls.Clear();
                foreach (var card in room.Players[2].Cards)
                {
                    flwPlayer4.Controls.Add(new PictureBox
                    {
                        Image = Image.FromFile($@"{_resourcePath}{card.Card.ImageName}"),
                        Size = new Size(136, 167),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(-5)
                    });
                }
                flwPlayer4.Tag = room.Players[2].Identifier;
            }
        }
        else
        {
            flwPlayer4.Controls.Clear();
            flwPlayer4.Tag = null;
        }
    }

    private void ShowMyCards(GameInfoRoom room)
    {
        flwPlayer1.Controls.Clear();
        foreach (var card in room.Cards)
        {
            flwPlayer1.Controls.Add(new PictureBox
            {
                Image = Image.FromFile($@"{_resourcePath}{card.Card.ImageName}"),
                Size = new Size(136, 167),
                SizeMode = PictureBoxSizeMode.Zoom
            });
        }
        flwPlayer1.Tag = _playerId;
    }
}
