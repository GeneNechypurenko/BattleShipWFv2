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
            SuspendLayout();
            // 
            // computerFlowLayoutPanel
            // 
            computerFlowLayoutPanel.Location = new Point(390, 60);
            computerFlowLayoutPanel.Name = "computerFlowLayoutPanel";
            computerFlowLayoutPanel.Size = new Size(300, 300);
            computerFlowLayoutPanel.TabIndex = 2;
            // 
            // playerFlowLayoutPanel
            // 
            playerFlowLayoutPanel.Location = new Point(50, 60);
            playerFlowLayoutPanel.Name = "playerFlowLayoutPanel";
            playerFlowLayoutPanel.Size = new Size(300, 300);
            playerFlowLayoutPanel.TabIndex = 3;
            // 
            // GamePlayUserControl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            Controls.Add(playerFlowLayoutPanel);
            Controls.Add(computerFlowLayoutPanel);
            Name = "GamePlayUserControl";
            Size = new Size(742, 400);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel computerFlowLayoutPanel;
        private FlowLayoutPanel playerFlowLayoutPanel;
    }
}
