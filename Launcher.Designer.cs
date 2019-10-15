namespace Launcher
{
    partial class Launcher
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
            this.LaunchButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fileProgress = new System.Windows.Forms.ProgressBar();
            this.dlProgress = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ModPackComboBox = new System.Windows.Forms.ComboBox();
            this.logOutButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(568, 428);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(60, 23);
            this.LaunchButton.TabIndex = 0;
            this.LaunchButton.Text = "Login";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(602, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileProgress
            // 
            this.fileProgress.ForeColor = System.Drawing.Color.OliveDrab;
            this.fileProgress.Location = new System.Drawing.Point(13, 458);
            this.fileProgress.Name = "fileProgress";
            this.fileProgress.Size = new System.Drawing.Size(495, 10);
            this.fileProgress.TabIndex = 2;
            // 
            // dlProgress
            // 
            this.dlProgress.AutoSize = true;
            this.dlProgress.BackColor = System.Drawing.Color.Transparent;
            this.dlProgress.ForeColor = System.Drawing.SystemColors.Control;
            this.dlProgress.Location = new System.Drawing.Point(13, 433);
            this.dlProgress.Name = "dlProgress";
            this.dlProgress.Size = new System.Drawing.Size(67, 13);
            this.dlProgress.TabIndex = 3;
            this.dlProgress.Text = "File Progress";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 41);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(616, 386);
            this.webBrowser1.TabIndex = 4;
            this.webBrowser1.Url = new System.Uri("http://www.tech2logic.com/launcher1234", System.UriKind.Absolute);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLabel.Location = new System.Drawing.Point(396, 433);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(83, 13);
            this.welcomeLabel.TabIndex = 5;
            this.welcomeLabel.Text = "Welcome Guest";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ModPackComboBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 23);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titlebar_mouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titlebar_dragWindow);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titlebar_mouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(326, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Mod Pack";
            // 
            // ModPackComboBox
            // 
            this.ModPackComboBox.FormattingEnabled = true;
            this.ModPackComboBox.Location = new System.Drawing.Point(460, 2);
            this.ModPackComboBox.Name = "ModPackComboBox";
            this.ModPackComboBox.Size = new System.Drawing.Size(121, 21);
            this.ModPackComboBox.TabIndex = 0;
            this.ModPackComboBox.SelectedIndexChanged += new System.EventHandler(this.modPackChanged);
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(568, 457);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(60, 22);
            this.logOutButton.TabIndex = 7;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(514, 428);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.dlProgress);
            this.Controls.Add(this.fileProgress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Launcher";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "T2L Launcher";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar fileProgress;
        private System.Windows.Forms.Label dlProgress;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ModPackComboBox;
    }
}

