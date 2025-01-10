namespace Client;

partial class FrmLauncher
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        btnLaunchClient = new Button();
        timerTestConnection = new System.Windows.Forms.Timer(components);
        lblErrorMessage = new Label();
        pgrBarTestConnection = new ProgressBar();
        lblPlayerId = new Label();
        SuspendLayout();
        // 
        // btnLaunchClient
        // 
        btnLaunchClient.Location = new Point(40, 93);
        btnLaunchClient.Name = "btnLaunchClient";
        btnLaunchClient.Size = new Size(702, 110);
        btnLaunchClient.TabIndex = 0;
        btnLaunchClient.Text = "Find and Enter Room";
        btnLaunchClient.UseVisualStyleBackColor = true;
        btnLaunchClient.Click += btnLaunchClient_Click;
        // 
        // timerTestConnection
        // 
        timerTestConnection.Enabled = true;
        timerTestConnection.Interval = 1000;
        timerTestConnection.Tick += timerTestConnection_Tick;
        // 
        // lblErrorMessage
        // 
        lblErrorMessage.AutoSize = true;
        lblErrorMessage.Location = new Point(40, 282);
        lblErrorMessage.Name = "lblErrorMessage";
        lblErrorMessage.Size = new Size(266, 25);
        lblErrorMessage.TabIndex = 1;
        lblErrorMessage.Text = "Connecting to Blackjack game ...";
        // 
        // pgrBarTestConnection
        // 
        pgrBarTestConnection.Location = new Point(40, 229);
        pgrBarTestConnection.Name = "pgrBarTestConnection";
        pgrBarTestConnection.Size = new Size(702, 34);
        pgrBarTestConnection.TabIndex = 2;
        // 
        // lblPlayerId
        // 
        lblPlayerId.AutoSize = true;
        lblPlayerId.Location = new Point(40, 29);
        lblPlayerId.Name = "lblPlayerId";
        lblPlayerId.Size = new Size(279, 25);
        lblPlayerId.TabIndex = 3;
        lblPlayerId.Text = "Player Id: 28821nud2wnud19d81j";
        // 
        // FrmLauncher
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(797, 349);
        Controls.Add(lblPlayerId);
        Controls.Add(pgrBarTestConnection);
        Controls.Add(lblErrorMessage);
        Controls.Add(btnLaunchClient);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "FrmLauncher";
        Text = "FrmLauncher";
        Load += FrmLauncher_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnLaunchClient;
    private System.Windows.Forms.Timer timerTestConnection;
    private Label lblErrorMessage;
    private ProgressBar pgrBarTestConnection;
    private Label lblPlayerId;
}