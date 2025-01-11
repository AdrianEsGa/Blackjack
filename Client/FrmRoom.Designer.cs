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
        pbCrupierCard2 = new PictureBox();
        pbCrupierCard1 = new PictureBox();
        pbPlayer1Card1 = new PictureBox();
        pbPlayer1Card2 = new PictureBox();
        pbPlayer2Card1 = new PictureBox();
        pbPlayer2Card2 = new PictureBox();
        pbPlayer3Card1 = new PictureBox();
        pbPlayer3Card2 = new PictureBox();
        pbPlayer4Card1 = new PictureBox();
        pbPlayer4Card2 = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)pbCrupierCard2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbCrupierCard1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer1Card1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer1Card2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer2Card1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer2Card2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer3Card1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer3Card2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer4Card1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer4Card2).BeginInit();
        SuspendLayout();
        // 
        // btnOutRoom
        // 
        btnOutRoom.Location = new Point(1111, 12);
        btnOutRoom.Name = "btnOutRoom";
        btnOutRoom.Size = new Size(143, 62);
        btnOutRoom.TabIndex = 8;
        btnOutRoom.Text = "Out room";
        btnOutRoom.UseVisualStyleBackColor = true;
        btnOutRoom.Click += btnOutRoom_Click;
        // 
        // btnSkip
        // 
        btnSkip.Location = new Point(682, 653);
        btnSkip.Name = "btnSkip";
        btnSkip.Size = new Size(144, 45);
        btnSkip.TabIndex = 6;
        btnSkip.Text = "Skip";
        btnSkip.UseVisualStyleBackColor = true;
        btnSkip.Click += btnSkip_Click;
        // 
        // btnTakeCard
        // 
        btnTakeCard.Location = new Point(515, 653);
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
        lblPlayerId.Location = new Point(23, 31);
        lblPlayerId.Name = "lblPlayerId";
        lblPlayerId.Size = new Size(279, 25);
        lblPlayerId.TabIndex = 9;
        lblPlayerId.Text = "Player Id: 28821nud2wnud19d81j";
        // 
        // pbCrupierCard2
        // 
        pbCrupierCard2.Location = new Point(657, 65);
        pbCrupierCard2.Name = "pbCrupierCard2";
        pbCrupierCard2.Size = new Size(136, 167);
        pbCrupierCard2.SizeMode = PictureBoxSizeMode.Zoom;
        pbCrupierCard2.TabIndex = 11;
        pbCrupierCard2.TabStop = false;
        // 
        // pbCrupierCard1
        // 
        pbCrupierCard1.Location = new Point(515, 65);
        pbCrupierCard1.Name = "pbCrupierCard1";
        pbCrupierCard1.Size = new Size(136, 167);
        pbCrupierCard1.SizeMode = PictureBoxSizeMode.Zoom;
        pbCrupierCard1.TabIndex = 12;
        pbCrupierCard1.TabStop = false;
        // 
        // pbPlayer1Card1
        // 
        pbPlayer1Card1.Location = new Point(35, 227);
        pbPlayer1Card1.Name = "pbPlayer1Card1";
        pbPlayer1Card1.Size = new Size(136, 167);
        pbPlayer1Card1.SizeMode = PictureBoxSizeMode.Zoom;
        pbPlayer1Card1.TabIndex = 14;
        pbPlayer1Card1.TabStop = false;
        // 
        // pbPlayer1Card2
        // 
        pbPlayer1Card2.Location = new Point(177, 227);
        pbPlayer1Card2.Name = "pbPlayer1Card2";
        pbPlayer1Card2.Size = new Size(136, 167);
        pbPlayer1Card2.SizeMode = PictureBoxSizeMode.Zoom;
        pbPlayer1Card2.TabIndex = 13;
        pbPlayer1Card2.TabStop = false;
        // 
        // pbPlayer2Card1
        // 
        pbPlayer2Card1.Location = new Point(340, 440);
        pbPlayer2Card1.Name = "pbPlayer2Card1";
        pbPlayer2Card1.Size = new Size(136, 167);
        pbPlayer2Card1.SizeMode = PictureBoxSizeMode.Zoom;
        pbPlayer2Card1.TabIndex = 16;
        pbPlayer2Card1.TabStop = false;
        // 
        // pbPlayer2Card2
        // 
        pbPlayer2Card2.Location = new Point(482, 440);
        pbPlayer2Card2.Name = "pbPlayer2Card2";
        pbPlayer2Card2.Size = new Size(136, 167);
        pbPlayer2Card2.SizeMode = PictureBoxSizeMode.Zoom;
        pbPlayer2Card2.TabIndex = 15;
        pbPlayer2Card2.TabStop = false;
        // 
        // pbPlayer3Card1
        // 
        pbPlayer3Card1.Location = new Point(706, 440);
        pbPlayer3Card1.Name = "pbPlayer3Card1";
        pbPlayer3Card1.Size = new Size(136, 167);
        pbPlayer3Card1.SizeMode = PictureBoxSizeMode.Zoom;
        pbPlayer3Card1.TabIndex = 18;
        pbPlayer3Card1.TabStop = false;
        // 
        // pbPlayer3Card2
        // 
        pbPlayer3Card2.Location = new Point(848, 440);
        pbPlayer3Card2.Name = "pbPlayer3Card2";
        pbPlayer3Card2.Size = new Size(136, 167);
        pbPlayer3Card2.SizeMode = PictureBoxSizeMode.Zoom;
        pbPlayer3Card2.TabIndex = 17;
        pbPlayer3Card2.TabStop = false;
        // 
        // pbPlayer4Card1
        // 
        pbPlayer4Card1.Location = new Point(1019, 227);
        pbPlayer4Card1.Name = "pbPlayer4Card1";
        pbPlayer4Card1.Size = new Size(136, 167);
        pbPlayer4Card1.SizeMode = PictureBoxSizeMode.Zoom;
        pbPlayer4Card1.TabIndex = 20;
        pbPlayer4Card1.TabStop = false;
        // 
        // pbPlayer4Card2
        // 
        pbPlayer4Card2.Location = new Point(1161, 227);
        pbPlayer4Card2.Name = "pbPlayer4Card2";
        pbPlayer4Card2.Size = new Size(136, 167);
        pbPlayer4Card2.SizeMode = PictureBoxSizeMode.Zoom;
        pbPlayer4Card2.TabIndex = 19;
        pbPlayer4Card2.TabStop = false;
        // 
        // FrmRoom
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1337, 710);
        Controls.Add(pbPlayer4Card1);
        Controls.Add(pbPlayer4Card2);
        Controls.Add(pbPlayer3Card1);
        Controls.Add(pbPlayer3Card2);
        Controls.Add(pbPlayer2Card1);
        Controls.Add(pbPlayer2Card2);
        Controls.Add(pbPlayer1Card1);
        Controls.Add(pbPlayer1Card2);
        Controls.Add(pbCrupierCard1);
        Controls.Add(pbCrupierCard2);
        Controls.Add(lblPlayerId);
        Controls.Add(btnOutRoom);
        Controls.Add(btnSkip);
        Controls.Add(btnTakeCard);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "FrmRoom";
        Text = "Room";
        FormClosing += FrmRoom_FormClosing;
        Load += FrmRoom_Load;
        ((System.ComponentModel.ISupportInitialize)pbCrupierCard2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbCrupierCard1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer1Card1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer1Card2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer2Card1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer2Card2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer3Card1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer3Card2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer4Card1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbPlayer4Card2).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button btnOutRoom;
    private Button btnSkip;
    private Button btnTakeCard;
    private System.Windows.Forms.Timer timerCheckTurn;
    private Label lblPlayerId;
    private PictureBox pbCrupierCard2;
    private PictureBox pbCrupierCard1;
    private PictureBox pbPlayer1Card1;
    private PictureBox pbPlayer1Card2;
    private PictureBox pbPlayer2Card1;
    private PictureBox pbPlayer2Card2;
    private PictureBox pbPlayer3Card1;
    private PictureBox pbPlayer3Card2;
    private PictureBox pbPlayer4Card1;
    private PictureBox pbPlayer4Card2;
}
