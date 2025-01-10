using Shared;

namespace Client;

public partial class FrmLauncher : Form
{
    private Guid PlayerId { get; set; }

    public FrmLauncher()
    {
        InitializeComponent();
        PlayerId = Guid.NewGuid();
        lblPlayerId.Text = $"Player: {PlayerId}";
    }

    private void btnLaunchClient_Click(object sender, EventArgs e)
    {
        FrmRoom form = new(PlayerId);
        form.Show();
    }

    private void FrmLauncher_Load(object sender, EventArgs e)
    {
        btnLaunchClient.Enabled = false;
        pgrBarTestConnection.Style = ProgressBarStyle.Marquee;  
    }

    private void timerTestConnection_Tick(object sender, EventArgs e)
    {
        Thread thread = new Thread(TestConnection);
        thread.Start();     
    }

    private void TestConnection(object? obj)
    {
        var serverResponse = ClientInstance.Send(new ClientRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            Action = ActionType.TestConnection,
        });

        Invoke(new Action(() => UpdateScreen(serverResponse)));      
    }

    private void UpdateScreen(ServerResponse serverResponse)
    {
        if (serverResponse.Status == ResponseStatus.Success)
        {
            lblErrorMessage.Text = string.Empty;
            btnLaunchClient.Enabled = true;
            pgrBarTestConnection.Visible = false;   
        }
        else
        {
            lblErrorMessage.Text = serverResponse.ErrorMessage;
            btnLaunchClient.Enabled = false;
            pgrBarTestConnection.Visible = true;
        }
    }
}
