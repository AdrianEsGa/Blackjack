namespace Client;

partial class FrmRoom
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        btnOutRoom = new Button();
        btnSkip = new Button();
        btnTakeCard = new Button();
        timerCheckTurn = new System.Windows.Forms.Timer(components);
        lblPlayerId = new Label();
        flwPlayer1 = new FlowLayoutPanel();
        flwPlayer2 = new FlowLayoutPanel();
        flwPlayer3 = new FlowLayoutPanel();
        flwPlayer4 = new FlowLayoutPanel();
        lblGameStatus = new Label();
        flwCrupier = new FlowLayoutPanel();
        SuspendLayout();
        // 
        // btnOutRoom
        // 
        btnOutRoom.Location = new Point(1205, 12);
        btnOutRoom.Name = "btnOutRoom";
        btnOutRoom.Size = new Size(143, 62);
        btnOutRoom.TabIndex = 8;
        btnOutRoom.Text = "Out room";
        btnOutRoom.UseVisualStyleBackColor = true;
        btnOutRoom.Click += btnOutRoom_Click;
        // 
        // btnSkip
        // 
        btnSkip.Location = new Point(694, 777);
        btnSkip.Name = "btnSkip";
        btnSkip.Size = new Size(144, 45);
        btnSkip.TabIndex = 6;
        btnSkip.Text = "Skip";
        btnSkip.UseVisualStyleBackColor = true;
        btnSkip.Click += btnSkip_Click;
        // 
        // btnTakeCard
        // 
        btnTakeCard.Location = new Point(527, 777);
        btnTakeCard.Name = "btnTakeCard";
        btnTakeCard.Size = new Size(148, 45);
        btnTakeCard.TabIndex = 5;
        btnTakeCard.Text = "Take card";
        btnTakeCard.UseVisualStyleBackColor = true;
        btnTakeCard.Click += btnTakeCard_Click;
        // 
        // timerCheckTurn
        // 
        timerCheckTurn.Enabled = true;
        timerCheckTurn.Interval = 1000;
        timerCheckTurn.Tick += timerCheckTurn_Tick;
        // 
        // lblPlayerId
        // 
        lblPlayerId.AutoSize = true;
        lblPlayerId.Location = new Point(12, 12);
        lblPlayerId.Name = "lblPlayerId";
        lblPlayerId.Size = new Size(279, 25);
        lblPlayerId.TabIndex = 9;
        lblPlayerId.Text = "Player Id: 28821nud2wnud19d81j";
        // 
        // flwPlayer1
        // 
        flwPlayer1.AutoSize = true;
        flwPlayer1.Location = new Point(12, 298);
        flwPlayer1.Margin = new Padding(0);
        flwPlayer1.Name = "flwPlayer1";
        flwPlayer1.RightToLeft = RightToLeft.Yes;
        flwPlayer1.Size = new Size(279, 193);
        flwPlayer1.TabIndex = 21;
        // 
        // flwPlayer2
        // 
        flwPlayer2.AutoSize = true;
        flwPlayer2.Location = new Point(320, 564);
        flwPlayer2.Name = "flwPlayer2";
        flwPlayer2.RightToLeft = RightToLeft.Yes;
        flwPlayer2.Size = new Size(279, 193);
        flwPlayer2.TabIndex = 22;
        // 
        // flwPlayer3
        // 
        flwPlayer3.AutoSize = true;
        flwPlayer3.Location = new Point(712, 564);
        flwPlayer3.Name = "flwPlayer3";
        flwPlayer3.RightToLeft = RightToLeft.Yes;
        flwPlayer3.Size = new Size(279, 193);
        flwPlayer3.TabIndex = 23;
        // 
        // flwPlayer4
        // 
        flwPlayer4.AutoSize = true;
        flwPlayer4.Location = new Point(1053, 298);
        flwPlayer4.Name = "flwPlayer4";
        flwPlayer4.RightToLeft = RightToLeft.Yes;
        flwPlayer4.Size = new Size(279, 193);
        flwPlayer4.TabIndex = 24;
        // 
        // lblGameStatus
        // 
        lblGameStatus.AutoSize = true;
        lblGameStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblGameStatus.ForeColor = Color.FromArgb(0, 192, 0);
        lblGameStatus.Location = new Point(548, 25);
        lblGameStatus.Name = "lblGameStatus";
        lblGameStatus.Size = new Size(127, 32);
        lblGameStatus.TabIndex = 25;
        lblGameStatus.Text = "Playing ...";
        // 
        // flwCrupier
        // 
        flwCrupier.AutoSize = true;
        flwCrupier.Location = new Point(527, 90);
        flwCrupier.Margin = new Padding(0);
        flwCrupier.Name = "flwCrupier";
        flwCrupier.RightToLeft = RightToLeft.Yes;
        flwCrupier.Size = new Size(279, 193);
        flwCrupier.TabIndex = 26;
        // 
        // FrmRoom
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1368, 876);
        ControlBox = false;
        Controls.Add(flwCrupier);
        Controls.Add(lblGameStatus);
        Controls.Add(flwPlayer4);
        Controls.Add(flwPlayer3);
        Controls.Add(flwPlayer2);
        Controls.Add(flwPlayer1);
        Controls.Add(lblPlayerId);
        Controls.Add(btnOutRoom);
        Controls.Add(btnSkip);
        Controls.Add(btnTakeCard);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        MaximizeBox = false;
        Name = "FrmRoom";
        Text = "Room";
        FormClosing += FrmRoom_FormClosing;
        Load += FrmRoom_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button btnOutRoom;
    private Button btnSkip;
    private Button btnTakeCard;
    private System.Windows.Forms.Timer timerCheckTurn;
    private Label lblPlayerId;
    private FlowLayoutPanel flwPlayer1;
    private FlowLayoutPanel flwPlayer2;
    private FlowLayoutPanel flwPlayer3;
    private FlowLayoutPanel flwPlayer4;
    private Label lblGameStatus;
    private FlowLayoutPanel flwCrupier;
}
