using Client.Core;
using System.Text.Json;

namespace Client;

public partial class FrmRoom : Form
{
    private Engine _engine;

    public FrmRoom()
    {
        InitializeComponent();
        _engine = new Engine();
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

        txtMessage.Text = JsonSerializer.Serialize(_engine.GetGameInfo());
        btnOutRoom.Enabled = _engine.IsInRoom();

        btnTakeCard.Enabled = _engine.IsPlaying();
        btnSkip.Enabled = _engine.IsPlaying();
    }

    private void btnNewPlayer_Click(object sender, EventArgs e)
    {
        FrmRoom form = new FrmRoom();
        form.Show();
    }

    private void FrmRoom_FormClosing(object sender, FormClosingEventArgs e)
    {
        _engine.OutRoom();
    }
}
