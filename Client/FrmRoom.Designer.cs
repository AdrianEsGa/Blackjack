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
        tableLayoutPanel1 = new TableLayoutPanel();
        SuspendLayout();
        // 
        // txtMessage
        // 
        txtMessage.Location = new Point(75, 563);
        txtMessage.Multiline = true;
        txtMessage.Name = "txtMessage";
        txtMessage.Size = new Size(1147, 182);
        txtMessage.TabIndex = 0;
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
        btnSkip.Location = new Point(639, 767);
        btnSkip.Name = "btnSkip";
        btnSkip.Size = new Size(144, 45);
        btnSkip.TabIndex = 6;
        btnSkip.Text = "Skip";
        btnSkip.UseVisualStyleBackColor = true;
        btnSkip.Click += btnSkip_Click;
        // 
        // btnTakeCard
        // 
        btnTakeCard.Location = new Point(468, 767);
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
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Location = new Point(130, 63);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.Size = new Size(842, 413);
        tableLayoutPanel1.TabIndex = 9;
        // 
        // FrmRoom
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1266, 832);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(btnOutRoom);
        Controls.Add(btnSkip);
        Controls.Add(btnTakeCard);
        Controls.Add(txtMessage);
        Name = "FrmRoom";
        Text = "Room";
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
    private TableLayoutPanel tableLayoutPanel1;
}
