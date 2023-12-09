using BattleShip.Models;
using BattleShip.ViewModel;
using RadioButton = System.Windows.Forms.RadioButton;

namespace BattleShip.View
{
    public partial class ShipsSetupUserControl : UserControl
    {
        private MainForm mainForm;

        private Player player;
        private Player computer;

        private ShipSetupViewModel viewModel;
        public RadioButton LincoreRadioButton { get => lincoreRadioButton; }
        public RadioButton FregateRadioButton { get => fregateRadioButton; }
        public RadioButton CorvetteRadioButton { get => corvetteRadioButton; }
        public RadioButton BriggRadioButton { get => briggRadioButton; }
        public CheckBox RotateCheckBox { get => rotateCheckBox; }
        public Label NotificationLabel { get => notificationLabel; }
        public FlowLayoutPanel CellsFlowLayoutPanel { get => cellsFlowLayoutPanel; }
        public ShipsSetupUserControl(MainForm mainForm, Player player, Player computer)
        {
            this.player = player;
            this.computer = computer;
            this.mainForm = mainForm;
            viewModel = new ShipSetupViewModel(player, computer, this, mainForm);
            InitializeComponent();
            Paint += ShipsSetupUserControl_Paint;
            InitializeNotificationLabels();

            Load += (s, e) =>
            {
                lincoreSetLabel.DataBindings.Add("Text", player, "LincoreSet");
                fregateSetLabel.DataBindings.Add("Text", player, "FregateSet");
                corvetteSetLabel.DataBindings.Add("Text", player, "CorvetteSet");
                briggSetLabel.DataBindings.Add("Text", player, "BriggSet");
            };

            viewModel.SetComputerBoard(computer);
        }
        private void InitializeNotificationLabels()
        {
            foreach (RadioButton selectedRadioButton in fleetGroupBox.Controls.OfType<RadioButton>())
            {
                if (selectedRadioButton.Checked)
                {
                    shipSelectedLabel.Text = $"SHIP SELECTED {selectedRadioButton.Tag.ToString()}";
                    selectedRadioButton.CheckedChanged += SelectedRadioButton_CheckedChanged;
                }
            }

            if (rotateCheckBox.Checked)
            {
                orientationSelectedLabel.Text = "ORIENTATION VERTICAL";
            }
            else
            {
                orientationSelectedLabel.Text = "ORIENTATION HORIZONTAL";
            }
            rotateCheckBox.CheckedChanged += RotateCheckBox_CheckedChanged;
        }

        private void RotateCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (rotateCheckBox.Checked)
            {
                orientationSelectedLabel.Text = "ORIENTATION VERTICAL";
            }
            else
            {
                orientationSelectedLabel.Text = "ORIENTATION HORIZONTAL";
            }
        }
        private void SelectedRadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            foreach (RadioButton selectedRadioButton in fleetGroupBox.Controls.OfType<RadioButton>())
            {
                if (selectedRadioButton.Checked)
                {
                    shipSelectedLabel.ForeColor = Color.Ivory;
                    shipSelectedLabel.Text = $"SHIP SELECTED {selectedRadioButton.Tag.ToString()}";
                    selectedRadioButton.CheckedChanged += SelectedRadioButton_CheckedChanged;
                }
            }
        }
        private void ShipsSetupUserControl_Paint(object? sender, PaintEventArgs e)
        {
            using (Graphics graphics = e.Graphics)
            {
                BoardRenderer.DrawBorderSideString(190, 0, Brushes.LimeGreen, e.Graphics, this.Font);
                BoardRenderer.AddPictureBoxes(cellsFlowLayoutPanel, Color.LimeGreen, CellPictureBox_Click);
                BoardRenderer.DrawBorderTopString(190, 0, Brushes.LimeGreen, e.Graphics, this.Font);
            };
        }
        private void CellPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            viewModel.SetPlayerShip(player, clickedPictureBox);
        }
    }
}