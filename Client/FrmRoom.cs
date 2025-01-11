using Client.Core;

namespace Client;

public partial class FrmRoom : Form
{
    private Engine _engine;
    private Guid _playerId;

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

    private void RefreshScreen()
    {
        Text = _engine.IsInRoom() ? $"Room {_engine.GetGameInfo().Room!.Indentifier}" : "Lobby";

        btnOutRoom.Enabled = _engine.IsInRoom();

        btnTakeCard.Enabled = _engine.IsPlaying();
        btnSkip.Enabled = _engine.IsPlaying();

        ShowCards();
    }

    private void ShowCards()
    {
        if (!_engine.IsInRoom()) return;

        var room = _engine.GetGameInfo().Room!;

        var basePath = @$"{Application.StartupPath}/Resources/Images/";

        //Crupier cards
        pbCrupierCard1.Image = Image.FromFile(@$"{basePath}{room.Crupier.Cards[0].Card.ImageName}");
        pbCrupierCard2.Image = Image.FromFile(@$"{basePath}{room.Crupier.Cards[1].Card.ImageName}");

        //My cards
        pbPlayer1Card1.Image = Image.FromFile($@"{basePath}{room.Cards[0].Card.ImageName}");
        pbPlayer1Card2.Image = Image.FromFile($@"{basePath}{room.Cards[1].Card.ImageName}");

        //Players
        if (room.Players.Count >= 1)
        {
            pbPlayer2Card1.Image = Image.FromFile($@"{basePath}{room.Players[0].Cards[0].Card.ImageName}");
            pbPlayer2Card2.Image = Image.FromFile($@"{basePath}{room.Players[0].Cards[1].Card.ImageName}");
        }
        else
        {
            pbPlayer2Card1.Image = null;
            pbPlayer2Card2.Image = null;
        }

        if (room.Players.Count >= 2)
        {
            pbPlayer3Card1.Image = Image.FromFile($@"{basePath}{room.Players[1].Cards[0].Card.ImageName}");
            pbPlayer3Card2.Image = Image.FromFile($@"{basePath}{room.Players[1].Cards[1].Card.ImageName}");
        }
        else
        {
            pbPlayer3Card1.Image = null;
            pbPlayer3Card2.Image = null;
        }

        if (room.Players.Count == 3)
        {
            pbPlayer4Card1.Image = Image.FromFile($@"{basePath}{room.Players[2].Cards[0].Card.ImageName}");
            pbPlayer4Card2.Image = Image.FromFile($@"{basePath}{room.Players[2].Cards[1].Card.ImageName}");
        }
        else
        {
            pbPlayer4Card1.Image = null;
            pbPlayer4Card2.Image = null;
        }
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
}
