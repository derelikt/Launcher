namespace Launcher
{
    partial class DebugWindow
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
            this.debugBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // debugBox
            // 
            this.debugBox.Location = new System.Drawing.Point(39, 48);
            this.debugBox.Name = "debugBox";
            this.debugBox.Size = new System.Drawing.Size(100, 96);
            this.debugBox.TabIndex = 0;
            this.debugBox.Text = "";
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 447);
            this.Controls.Add(this.debugBox);
            this.Name = "DebugWindow";
            this.Text = "DebugWindow";
            this.Load += new System.EventHandler(this.DebugWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox debugBox;
    }
}