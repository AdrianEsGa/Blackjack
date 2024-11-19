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
        txtMessage = new TextBox();
        btnOutRoom = new Button();
        btnSkip = new Button();
        btnTakeCard = new Button();
        timerCheckTurn = new System.Windows.Forms.Timer(components);
        SuspendLayout();
        // 
        // txtMessage
        // 
        txtMessage.Location = new Point(34, 64);
        txtMessage.Multiline = true;
        txtMessage.Name = "txtMessage";
        txtMessage.Size = new Size(654, 182);
        txtMessage.TabIndex = 0;
        // 
        // btnOutRoom
        // 
        btnOutRoom.Location = new Point(576, 12);
        btnOutRoom.Name = "btnOutRoom";
        btnOutRoom.Size = new Size(112, 34);
        btnOutRoom.TabIndex = 8;
        btnOutRoom.Text = "Out room";
        btnOutRoom.UseVisualStyleBackColor = true;
        btnOutRoom.Click += btnOutRoom_Click;
        // 
        // btnSkip
        // 
        btnSkip.Location = new Point(340, 268);
        btnSkip.Name = "btnSkip";
        btnSkip.Size = new Size(144, 45);
        btnSkip.TabIndex = 6;
        btnSkip.Text = "Skip";
        btnSkip.UseVisualStyleBackColor = true;
        btnSkip.Click += btnSkip_Click;
        // 
        // btnTakeCard
        // 
        btnTakeCard.Location = new Point(169, 268);
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
        // FrmRoom
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(716, 339);
        Controls.Add(btnOutRoom);
        Controls.Add(btnSkip);
        Controls.Add(btnTakeCard);
        Controls.Add(txtMessage);
        Name = "FrmRoom";
        Text = "Form1";
        FormClosing += FrmRoom_FormClosing;
        Load += FrmRoom_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtMessage;
    private Button btnOutRoom;
    private Button btnSkip;
    private Button btnTakeCard;
    private System.Windows.Forms.Timer timerCheckTurn;
}
