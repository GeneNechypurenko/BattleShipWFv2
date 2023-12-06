namespace BattleShip
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
            startScreenPanel = new Panel();
            startScreenLabel = new Label();
            buttonPanel = new Panel();
            startScreenButton = new Button();
            startScreenPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // startScreenPanel
            // 
            startScreenPanel.Controls.Add(startScreenLabel);
            startScreenPanel.Dock = DockStyle.Top;
            startScreenPanel.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startScreenPanel.ForeColor = Color.Ivory;
            startScreenPanel.Location = new Point(0, 0);
            startScreenPanel.Name = "startScreenPanel";
            startScreenPanel.Size = new Size(742, 344);
            startScreenPanel.TabIndex = 0;
            // 
            // startScreenLabel
            // 
            startScreenLabel.AutoSize = true;
            startScreenLabel.Dock = DockStyle.Fill;
            startScreenLabel.Font = new Font("Bahnschrift SemiBold Condensed", 72F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startScreenLabel.ForeColor = Color.Ivory;
            startScreenLabel.Location = new Point(0, 0);
            startScreenLabel.Name = "startScreenLabel";
            startScreenLabel.Padding = new Padding(100, 100, 100, 100);
            startScreenLabel.Size = new Size(742, 344);
            startScreenLabel.TabIndex = 0;
            startScreenLabel.Text = "BATTLE SHIP";
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(startScreenButton);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonPanel.ForeColor = Color.Ivory;
            buttonPanel.Location = new Point(0, 344);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(742, 59);
            buttonPanel.TabIndex = 1;
            // 
            // startScreenButton
            // 
            startScreenButton.Dock = DockStyle.Bottom;
            startScreenButton.FlatAppearance.BorderSize = 0;
            startScreenButton.FlatStyle = FlatStyle.Flat;
            startScreenButton.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startScreenButton.ForeColor = Color.Ivory;
            startScreenButton.Location = new Point(0, 0);
            startScreenButton.Margin = new Padding(10, 10, 10, 10);
            startScreenButton.Name = "startScreenButton";
            startScreenButton.Size = new Size(742, 59);
            startScreenButton.TabIndex = 0;
            startScreenButton.Text = "START NEW GAME";
            startScreenButton.UseVisualStyleBackColor = true;
            startScreenButton.Click += startScreenButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(742, 403);
            Controls.Add(buttonPanel);
            Controls.Add(startScreenPanel);
            ForeColor = Color.Ivory;
            MaximizeBox = false;
            Name = "MainForm";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Battle Ship";
            startScreenPanel.ResumeLayout(false);
            startScreenPanel.PerformLayout();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel startScreenPanel;
        private Label startScreenLabel;
        private Panel buttonPanel;
        private Button startScreenButton;
    }
}
