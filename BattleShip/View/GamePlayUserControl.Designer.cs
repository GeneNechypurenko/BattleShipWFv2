namespace BattleShip.View
{
    partial class GamePlayUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            computerFlowLayoutPanel = new FlowLayoutPanel();
            playerFlowLayoutPanel = new FlowLayoutPanel();
            pLabel = new Label();
            cLabel = new Label();
            playerShipCountLabel = new Label();
            computerShipCountLabel = new Label();
            playerTurnLabel = new Label();
            computerTurnLabel = new Label();
            SuspendLayout();
            // 
            // computerFlowLayoutPanel
            // 
            computerFlowLayoutPanel.BackColor = Color.Crimson;
            computerFlowLayoutPanel.Location = new Point(390, 60);
            computerFlowLayoutPanel.Name = "computerFlowLayoutPanel";
            computerFlowLayoutPanel.Size = new Size(300, 300);
            computerFlowLayoutPanel.TabIndex = 2;
            // 
            // playerFlowLayoutPanel
            // 
            playerFlowLayoutPanel.BackColor = Color.LimeGreen;
            playerFlowLayoutPanel.Location = new Point(50, 60);
            playerFlowLayoutPanel.Name = "playerFlowLayoutPanel";
            playerFlowLayoutPanel.Size = new Size(300, 300);
            playerFlowLayoutPanel.TabIndex = 3;
            // 
            // pLabel
            // 
            pLabel.AutoSize = true;
            pLabel.ForeColor = Color.LimeGreen;
            pLabel.Location = new Point(50, 363);
            pLabel.Name = "pLabel";
            pLabel.Size = new Size(95, 20);
            pLabel.TabIndex = 4;
            pLabel.Text = "SHIPS LEFT: ";
            // 
            // cLabel
            // 
            cLabel.AutoSize = true;
            cLabel.ForeColor = Color.Crimson;
            cLabel.Location = new Point(390, 363);
            cLabel.Name = "cLabel";
            cLabel.Size = new Size(95, 20);
            cLabel.TabIndex = 5;
            cLabel.Text = "SHIPS LEFT: ";
            // 
            // playerShipCountLabel
            // 
            playerShipCountLabel.AutoSize = true;
            playerShipCountLabel.ForeColor = Color.LimeGreen;
            playerShipCountLabel.Location = new Point(151, 363);
            playerShipCountLabel.Name = "playerShipCountLabel";
            playerShipCountLabel.Size = new Size(0, 20);
            playerShipCountLabel.TabIndex = 6;
            // 
            // computerShipCountLabel
            // 
            computerShipCountLabel.AutoSize = true;
            computerShipCountLabel.ForeColor = Color.Crimson;
            computerShipCountLabel.Location = new Point(491, 363);
            computerShipCountLabel.Name = "computerShipCountLabel";
            computerShipCountLabel.Size = new Size(0, 20);
            computerShipCountLabel.TabIndex = 7;
            // 
            // playerTurnLabel
            // 
            playerTurnLabel.AutoSize = true;
            playerTurnLabel.ForeColor = Color.LimeGreen;
            playerTurnLabel.Location = new Point(207, 363);
            playerTurnLabel.Name = "playerTurnLabel";
            playerTurnLabel.Size = new Size(0, 20);
            playerTurnLabel.TabIndex = 8;
            // 
            // computerTurnLabel
            // 
            computerTurnLabel.AutoSize = true;
            computerTurnLabel.ForeColor = Color.Crimson;
            computerTurnLabel.Location = new Point(549, 363);
            computerTurnLabel.Name = "computerTurnLabel";
            computerTurnLabel.Size = new Size(0, 20);
            computerTurnLabel.TabIndex = 9;
            // 
            // GamePlayUserControl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            Controls.Add(computerTurnLabel);
            Controls.Add(playerTurnLabel);
            Controls.Add(computerShipCountLabel);
            Controls.Add(playerShipCountLabel);
            Controls.Add(cLabel);
            Controls.Add(pLabel);
            Controls.Add(playerFlowLayoutPanel);
            Controls.Add(computerFlowLayoutPanel);
            Name = "GamePlayUserControl";
            Size = new Size(742, 400);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel computerFlowLayoutPanel;
        private FlowLayoutPanel playerFlowLayoutPanel;
        private Label pLabel;
        private Label cLabel;
        private Label playerShipCountLabel;
        private Label computerShipCountLabel;
        private Label playerTurnLabel;
        private Label computerTurnLabel;
    }
}
