namespace BattleShip.View
{
    partial class EndGameScreenForm
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
            endGameLabel = new Label();
            exitButton = new Button();
            SuspendLayout();
            // 
            // endGameLabel
            // 
            endGameLabel.AutoSize = true;
            endGameLabel.Dock = DockStyle.Fill;
            endGameLabel.Font = new Font("Bahnschrift SemiBold Condensed", 72F, FontStyle.Bold, GraphicsUnit.Point, 204);
            endGameLabel.ForeColor = Color.Ivory;
            endGameLabel.Location = new Point(0, 0);
            endGameLabel.Name = "endGameLabel";
            endGameLabel.Padding = new Padding(80, 100, 60, 100);
            endGameLabel.Size = new Size(965, 344);
            endGameLabel.TabIndex = 1;
            endGameLabel.Text = "YOU WON THE GAME!";
            // 
            // exitButton
            // 
            exitButton.Dock = DockStyle.Bottom;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            exitButton.ForeColor = Color.Ivory;
            exitButton.Location = new Point(0, 344);
            exitButton.Margin = new Padding(10);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(982, 59);
            exitButton.TabIndex = 2;
            exitButton.Text = "EXIT";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // EndGameScreenForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(982, 403);
            Controls.Add(exitButton);
            Controls.Add(endGameLabel);
            Name = "EndGameScreenForm";
            Opacity = 0.98D;
            Text = "EndGameScreenForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label endGameLabel;
        private Button exitButton;
    }
}