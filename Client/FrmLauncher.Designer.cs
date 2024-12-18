﻿namespace Client;

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
        SuspendLayout();
        // 
        // btnLaunchClient
        // 
        btnLaunchClient.Location = new Point(280, 129);
        btnLaunchClient.Name = "btnLaunchClient";
        btnLaunchClient.Size = new Size(208, 78);
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
        lblErrorMessage.Location = new Point(34, 396);
        lblErrorMessage.Name = "lblErrorMessage";
        lblErrorMessage.Size = new Size(266, 25);
        lblErrorMessage.TabIndex = 1;
        lblErrorMessage.Text = "Connecting to Blackjack game ...";
        // 
        // pgrBarTestConnection
        // 
        pgrBarTestConnection.Location = new Point(34, 343);
        pgrBarTestConnection.Name = "pgrBarTestConnection";
        pgrBarTestConnection.Size = new Size(713, 34);
        pgrBarTestConnection.TabIndex = 2;
        // 
        // FrmLauncher
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(786, 450);
        Controls.Add(pgrBarTestConnection);
        Controls.Add(lblErrorMessage);
        Controls.Add(btnLaunchClient);
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
}