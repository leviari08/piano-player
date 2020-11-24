namespace PianoPlayer
{
    partial class MainForm
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
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.butConnect = new System.Windows.Forms.Button();
            this.lblRoomID = new System.Windows.Forms.Label();
            this.butUp = new System.Windows.Forms.Button();
            this.butDown = new System.Windows.Forms.Button();
            this.lblTransposition = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butStop = new System.Windows.Forms.Button();
            this.butPlay = new System.Windows.Forms.Button();
            this.cmboxSongs = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRoomID
            // 
            this.txtRoomID.Location = new System.Drawing.Point(73, 12);
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.Size = new System.Drawing.Size(218, 23);
            this.txtRoomID.TabIndex = 0;
            // 
            // butConnect
            // 
            this.butConnect.Location = new System.Drawing.Point(297, 12);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(75, 23);
            this.butConnect.TabIndex = 1;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // lblRoomID
            // 
            this.lblRoomID.AutoSize = true;
            this.lblRoomID.Location = new System.Drawing.Point(12, 16);
            this.lblRoomID.Name = "lblRoomID";
            this.lblRoomID.Size = new System.Drawing.Size(55, 15);
            this.lblRoomID.TabIndex = 2;
            this.lblRoomID.Text = "Room id:";
            // 
            // butUp
            // 
            this.butUp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butUp.Location = new System.Drawing.Point(12, 194);
            this.butUp.Name = "butUp";
            this.butUp.Size = new System.Drawing.Size(50, 50);
            this.butUp.TabIndex = 3;
            this.butUp.Text = "↑";
            this.butUp.UseVisualStyleBackColor = true;
            this.butUp.Click += new System.EventHandler(this.butTransposition_Click);
            // 
            // butDown
            // 
            this.butDown.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.butDown.Location = new System.Drawing.Point(12, 250);
            this.butDown.Name = "butDown";
            this.butDown.Size = new System.Drawing.Size(50, 50);
            this.butDown.TabIndex = 4;
            this.butDown.Text = "↓";
            this.butDown.UseVisualStyleBackColor = true;
            this.butDown.Click += new System.EventHandler(this.butTransposition_Click);
            // 
            // lblTransposition
            // 
            this.lblTransposition.AutoSize = true;
            this.lblTransposition.Location = new System.Drawing.Point(12, 176);
            this.lblTransposition.Name = "lblTransposition";
            this.lblTransposition.Size = new System.Drawing.Size(13, 15);
            this.lblTransposition.TabIndex = 6;
            this.lblTransposition.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRoomID);
            this.panel1.Controls.Add(this.txtRoomID);
            this.panel1.Controls.Add(this.butConnect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 49);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butStop);
            this.panel2.Controls.Add(this.butPlay);
            this.panel2.Controls.Add(this.butDown);
            this.panel2.Controls.Add(this.butUp);
            this.panel2.Controls.Add(this.lblTransposition);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(310, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(74, 312);
            this.panel2.TabIndex = 8;
            // 
            // butStop
            // 
            this.butStop.Location = new System.Drawing.Point(12, 62);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(50, 50);
            this.butStop.TabIndex = 10;
            this.butStop.Text = "|  |";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // butPlay
            // 
            this.butPlay.Location = new System.Drawing.Point(12, 6);
            this.butPlay.Name = "butPlay";
            this.butPlay.Size = new System.Drawing.Size(50, 50);
            this.butPlay.TabIndex = 10;
            this.butPlay.Text = "Play";
            this.butPlay.UseVisualStyleBackColor = true;
            this.butPlay.Click += new System.EventHandler(this.butPlay_Click);
            // 
            // cmboxSongs
            // 
            this.cmboxSongs.AllowDrop = true;
            this.cmboxSongs.FormattingEnabled = true;
            this.cmboxSongs.Location = new System.Drawing.Point(73, 55);
            this.cmboxSongs.Name = "cmboxSongs";
            this.cmboxSongs.Size = new System.Drawing.Size(218, 23);
            this.cmboxSongs.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.cmboxSongs);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Piano player";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.Label lblRoomID;
        private System.Windows.Forms.Button butUp;
        private System.Windows.Forms.Button butDown;
        private System.Windows.Forms.Label lblTransposition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmboxSongs;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.Button butPlay;
    }
}

