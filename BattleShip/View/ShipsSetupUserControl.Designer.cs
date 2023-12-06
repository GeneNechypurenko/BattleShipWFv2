namespace BattleShip.View
{
    partial class ShipsSetupUserControl
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
            fleetGroupBox = new GroupBox();
            rotateCheckBox = new CheckBox();
            briggRadioButton = new RadioButton();
            corvetteRadioButton = new RadioButton();
            fregateRadioButton = new RadioButton();
            lincoreRadioButton = new RadioButton();
            groupBox1 = new GroupBox();
            label1 = new Label();
            infoLabel4 = new Label();
            infoLabel3 = new Label();
            infoLabel2 = new Label();
            infoLabel1 = new Label();
            orientationSelectedLabel = new Label();
            shipSelectedLabel = new Label();
            notificationLabel = new Label();
            cellsFlowLayoutPanel = new FlowLayoutPanel();
            lincoreSetLabel = new Label();
            fregateSetLabel = new Label();
            corvetteSetLabel = new Label();
            briggSetLabel = new Label();
            fleetGroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // fleetGroupBox
            // 
            fleetGroupBox.Controls.Add(rotateCheckBox);
            fleetGroupBox.Controls.Add(briggRadioButton);
            fleetGroupBox.Controls.Add(corvetteRadioButton);
            fleetGroupBox.Controls.Add(fregateRadioButton);
            fleetGroupBox.Controls.Add(lincoreRadioButton);
            fleetGroupBox.Dock = DockStyle.Right;
            fleetGroupBox.FlatStyle = FlatStyle.Flat;
            fleetGroupBox.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            fleetGroupBox.ForeColor = Color.Ivory;
            fleetGroupBox.Location = new Point(552, 0);
            fleetGroupBox.Margin = new Padding(10);
            fleetGroupBox.Name = "fleetGroupBox";
            fleetGroupBox.Padding = new Padding(10);
            fleetGroupBox.Size = new Size(190, 344);
            fleetGroupBox.TabIndex = 0;
            fleetGroupBox.TabStop = false;
            fleetGroupBox.Text = "SHIP SELECTION";
            // 
            // rotateCheckBox
            // 
            rotateCheckBox.AutoSize = true;
            rotateCheckBox.Location = new Point(86, 293);
            rotateCheckBox.Name = "rotateCheckBox";
            rotateCheckBox.Padding = new Padding(10);
            rotateCheckBox.Size = new Size(101, 48);
            rotateCheckBox.TabIndex = 4;
            rotateCheckBox.Text = "ROTATE";
            rotateCheckBox.UseVisualStyleBackColor = true;
            // 
            // briggRadioButton
            // 
            briggRadioButton.AutoSize = true;
            briggRadioButton.Location = new Point(10, 237);
            briggRadioButton.Name = "briggRadioButton";
            briggRadioButton.Padding = new Padding(10);
            briggRadioButton.Size = new Size(90, 48);
            briggRadioButton.TabIndex = 3;
            briggRadioButton.Tag = "BRIGG";
            briggRadioButton.Text = "BRIGG";
            briggRadioButton.UseVisualStyleBackColor = true;
            // 
            // corvetteRadioButton
            // 
            corvetteRadioButton.AutoSize = true;
            corvetteRadioButton.Location = new Point(10, 173);
            corvetteRadioButton.Name = "corvetteRadioButton";
            corvetteRadioButton.Padding = new Padding(10);
            corvetteRadioButton.Size = new Size(116, 48);
            corvetteRadioButton.TabIndex = 2;
            corvetteRadioButton.Tag = "CORVETTE";
            corvetteRadioButton.Text = "CORVETTE";
            corvetteRadioButton.UseVisualStyleBackColor = true;
            // 
            // fregateRadioButton
            // 
            fregateRadioButton.AutoSize = true;
            fregateRadioButton.Location = new Point(10, 109);
            fregateRadioButton.Name = "fregateRadioButton";
            fregateRadioButton.Padding = new Padding(10);
            fregateRadioButton.Size = new Size(107, 48);
            fregateRadioButton.TabIndex = 1;
            fregateRadioButton.Tag = "FREGATE";
            fregateRadioButton.Text = "FREGATE";
            fregateRadioButton.UseVisualStyleBackColor = true;
            // 
            // lincoreRadioButton
            // 
            lincoreRadioButton.AutoSize = true;
            lincoreRadioButton.Checked = true;
            lincoreRadioButton.Location = new Point(10, 45);
            lincoreRadioButton.Name = "lincoreRadioButton";
            lincoreRadioButton.Padding = new Padding(10);
            lincoreRadioButton.Size = new Size(105, 48);
            lincoreRadioButton.TabIndex = 0;
            lincoreRadioButton.TabStop = true;
            lincoreRadioButton.Tag = "LINCORE";
            lincoreRadioButton.Text = "LINCORE";
            lincoreRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(briggSetLabel);
            groupBox1.Controls.Add(corvetteSetLabel);
            groupBox1.Controls.Add(fregateSetLabel);
            groupBox1.Controls.Add(lincoreSetLabel);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(infoLabel4);
            groupBox1.Controls.Add(infoLabel3);
            groupBox1.Controls.Add(infoLabel2);
            groupBox1.Controls.Add(infoLabel1);
            groupBox1.Controls.Add(orientationSelectedLabel);
            groupBox1.Controls.Add(shipSelectedLabel);
            groupBox1.Controls.Add(notificationLabel);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Bahnschrift Condensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox1.ForeColor = Color.Ivory;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(10);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(184, 344);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 173);
            label1.Name = "label1";
            label1.Size = new Size(169, 24);
            label1.TabIndex = 7;
            label1.Text = "SHIPS FOR DEPLOYMENT:";
            // 
            // infoLabel4
            // 
            infoLabel4.AutoSize = true;
            infoLabel4.Location = new Point(3, 269);
            infoLabel4.Name = "infoLabel4";
            infoLabel4.Size = new Size(55, 24);
            infoLabel4.TabIndex = 6;
            infoLabel4.Text = "BRIGG: ";
            // 
            // infoLabel3
            // 
            infoLabel3.AutoSize = true;
            infoLabel3.Location = new Point(3, 245);
            infoLabel3.Name = "infoLabel3";
            infoLabel3.Size = new Size(82, 24);
            infoLabel3.TabIndex = 5;
            infoLabel3.Text = "CORVETTE: ";
            // 
            // infoLabel2
            // 
            infoLabel2.AutoSize = true;
            infoLabel2.Location = new Point(3, 221);
            infoLabel2.Name = "infoLabel2";
            infoLabel2.Size = new Size(73, 24);
            infoLabel2.TabIndex = 4;
            infoLabel2.Text = "FREGATE: ";
            // 
            // infoLabel1
            // 
            infoLabel1.AutoSize = true;
            infoLabel1.Location = new Point(3, 197);
            infoLabel1.Name = "infoLabel1";
            infoLabel1.Size = new Size(71, 24);
            infoLabel1.TabIndex = 3;
            infoLabel1.Text = "LINCORE: ";
            // 
            // orientationSelectedLabel
            // 
            orientationSelectedLabel.AutoSize = true;
            orientationSelectedLabel.Location = new Point(3, 131);
            orientationSelectedLabel.Name = "orientationSelectedLabel";
            orientationSelectedLabel.Size = new Size(0, 24);
            orientationSelectedLabel.TabIndex = 2;
            // 
            // shipSelectedLabel
            // 
            shipSelectedLabel.AutoSize = true;
            shipSelectedLabel.Location = new Point(3, 107);
            shipSelectedLabel.Name = "shipSelectedLabel";
            shipSelectedLabel.Size = new Size(0, 24);
            shipSelectedLabel.TabIndex = 1;
            // 
            // notificationLabel
            // 
            notificationLabel.AutoSize = true;
            notificationLabel.ForeColor = Color.Crimson;
            notificationLabel.Location = new Point(3, 57);
            notificationLabel.Name = "notificationLabel";
            notificationLabel.Size = new Size(0, 24);
            notificationLabel.TabIndex = 0;
            // 
            // cellsFlowLayoutPanel
            // 
            cellsFlowLayoutPanel.Location = new Point(220, 30);
            cellsFlowLayoutPanel.Margin = new Padding(0);
            cellsFlowLayoutPanel.Name = "cellsFlowLayoutPanel";
            cellsFlowLayoutPanel.Size = new Size(300, 300);
            cellsFlowLayoutPanel.TabIndex = 2;
            // 
            // lincoreSetLabel
            // 
            lincoreSetLabel.AutoSize = true;
            lincoreSetLabel.Location = new Point(80, 197);
            lincoreSetLabel.Name = "lincoreSetLabel";
            lincoreSetLabel.Size = new Size(0, 24);
            lincoreSetLabel.TabIndex = 8;
            // 
            // fregateSetLabel
            // 
            fregateSetLabel.AutoSize = true;
            fregateSetLabel.Location = new Point(80, 221);
            fregateSetLabel.Name = "fregateSetLabel";
            fregateSetLabel.Size = new Size(0, 24);
            fregateSetLabel.TabIndex = 9;
            // 
            // corvetteSetLabel
            // 
            corvetteSetLabel.AutoSize = true;
            corvetteSetLabel.Location = new Point(80, 245);
            corvetteSetLabel.Name = "corvetteSetLabel";
            corvetteSetLabel.Size = new Size(0, 24);
            corvetteSetLabel.TabIndex = 10;
            // 
            // briggSetLabel
            // 
            briggSetLabel.AutoSize = true;
            briggSetLabel.Location = new Point(80, 269);
            briggSetLabel.Name = "briggSetLabel";
            briggSetLabel.Size = new Size(0, 24);
            briggSetLabel.TabIndex = 11;
            // 
            // ShipsSetupUserControl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            Controls.Add(cellsFlowLayoutPanel);
            Controls.Add(groupBox1);
            Controls.Add(fleetGroupBox);
            Name = "ShipsSetupUserControl";
            Size = new Size(742, 344);
            fleetGroupBox.ResumeLayout(false);
            fleetGroupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox fleetGroupBox;
        private RadioButton lincoreRadioButton;
        private RadioButton briggRadioButton;
        private RadioButton corvetteRadioButton;
        private RadioButton fregateRadioButton;
        private CheckBox rotateCheckBox;
        private GroupBox groupBox1;
        private FlowLayoutPanel cellsFlowLayoutPanel;
        private Label notificationLabel;
        private Label shipSelectedLabel;
        private Label infoLabel4;
        private Label infoLabel3;
        private Label infoLabel2;
        private Label infoLabel1;
        private Label orientationSelectedLabel;
        private Label label1;
        private Label briggSetLabel;
        private Label corvetteSetLabel;
        private Label fregateSetLabel;
        private Label lincoreSetLabel;
    }
}
