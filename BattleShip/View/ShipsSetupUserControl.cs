using BattleShip.Models;
using RadioButton = System.Windows.Forms.RadioButton;

namespace BattleShip.View
{
    public partial class ShipsSetupUserControl : UserControl
    {
        private MainForm mainForm;

        private Player player;
        private Board board;
        public ShipsSetupUserControl(MainForm mainForm, Player player, Board board)
        {
            this.board = board;
            this.player = player;
            this.mainForm = mainForm;
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
        }
        private void InitializeNotificationLabels()
        {
            foreach (RadioButton selectedRadioButton in fleetGroupBox.Controls.OfType<RadioButton>())
            {
                if (selectedRadioButton.Checked)
                {
                    shipSelectedLabel.Text = $"SHIP SELECTED {selectedRadioButton.Tag.ToString()}";
                    selectedRadioButton.CheckedChanged += SelectedRadioButton_CheckedChanged;
                    selectedRadioButton.EnabledChanged += SelectedRadioButton_EnabledChanged;
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
        private void SelectedRadioButton_EnabledChanged(object? sender, EventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton.Checked && !selectedRadioButton.Enabled)
            {
                shipSelectedLabel.ForeColor = Color.Crimson;
                shipSelectedLabel.Text = $"NO SHIP SELECTED";
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
            DrawBorderTopString();
            AddPictureBoxes();
            DrawBorderLeftString();
        }
        private void AddPictureBoxes()
        {
            for (int i = 0; i < board.Cells; ++i)
            {
                for (int j = 0; j < board.Cells; ++j)
                {
                    PictureBox cellPictureBox = new PictureBox
                    {
                        Size = new Size(board.CellSize, board.CellSize),
                        Margin = new Padding(0),
                        Location = new Point(i * board.CellSize, j * board.CellSize),
                        Tag = $"{i}:{j}",
                        BackColor = Color.LightGray,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    cellsFlowLayoutPanel.Controls.Add(cellPictureBox);
                    cellPictureBox.Click += CellPictureBox_Click;
                }
            }
        }
        private void DrawBorderLeftString()
        {
            using (Graphics g = CreateGraphics())
            {
                int topStringOffset = 190;
                int leftStringOffset = 0;
                string leftString = "1234567890";

                foreach (var digit in leftString)
                {
                    leftStringOffset += board.CellSize;
                    g.DrawString(digit.ToString(), this.Font, Brushes.Ivory, new PointF(topStringOffset + board.CellSize / 4, leftStringOffset + board.CellSize / 4));
                }
            }
        }
        private void DrawBorderTopString()
        {
            using (Graphics g = CreateGraphics())
            {
                int topStringOffset = 190;
                string topString = "RESPUBLICA";

                foreach (var letter in topString)
                {
                    topStringOffset += board.CellSize;
                    g.DrawString(letter.ToString(), this.Font, Brushes.Ivory, new PointF(topStringOffset + board.CellSize / 4, board.CellSize / 4));
                }
            }
        }
        private void CellPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            if (lincoreRadioButton.Checked && player.LincoreSet != 0)
            {
                Ship ship = new Ship { Size = 4, IsSunk = false, IsVertical = false };
                PlaceShipOnBoard(ship, clickedPictureBox);
                if (player.LincoreSet == 0) { lincoreRadioButton.Enabled = false; }
            }
            else if (fregateRadioButton.Checked && player.FregateSet != 0)
            {
                Ship ship = new Ship { Size = 3, IsSunk = false, IsVertical = false };
                PlaceShipOnBoard(ship, clickedPictureBox);
                if (player.FregateSet == 0) { fregateRadioButton.Enabled = false; }
            }
            else if (corvetteRadioButton.Checked && player.CorvetteSet != 0)
            {
                Ship ship = new Ship { Size = 2, IsSunk = false, IsVertical = false };
                PlaceShipOnBoard(ship, clickedPictureBox);
                if (player.CorvetteSet == 0) { corvetteRadioButton.Enabled = false; }
            }
            else if (briggRadioButton.Checked && player.BriggSet != 0)
            {
                Ship ship = new Ship { Size = 1, IsSunk = false, IsVertical = false };
                PlaceShipOnBoard(ship, clickedPictureBox);
                if (player.BriggSet == 0) { briggRadioButton.Enabled = false; }
            }
        }
        private void PlaceShipOnBoard(Ship ship, PictureBox? clickedPictureBox)
        {
            string[] coordinates = clickedPictureBox.Tag.ToString().Split(':');

            if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int i) && int.TryParse(coordinates[1], out int j))
            {
                if (j <= board.Cells - ship.Size && !rotateCheckBox.Checked && !board.IsOccupiedCell[i, j] && !board.IsOccupiedCell[i, j + ship.Size - 1] ||
                    i <= board.Cells - ship.Size && rotateCheckBox.Checked && !board.IsOccupiedCell[i, j] && !board.IsOccupiedCell[i + ship.Size - 1, j])
                {
                    SetShipPosXY(ship, i, j);
                    SetCellPictureBoxColor(ship, i, j);
                    SetShipOnBoard(ship, i, j);

                    board.Ships.Add(ship);

                    notificationLabel.ForeColor = Color.LawnGreen;
                    notificationLabel.Text = "SHIP PLACED!";

                    if (player.LincoreSet == 0 && player.FregateSet == 0 && player.CorvetteSet == 0 && player.BriggSet == 0)
                    {
                        mainForm.StartGameButton.Enabled = true;
                    }
                }
                else
                {
                    notificationLabel.ForeColor = Color.Crimson;
                    notificationLabel.Text = "CAN'T PLACE SHIP THERE!";
                }
            }
        }
        private void SetShipOnBoard(Ship ship, int i, int j)
        {
            if (ship.IsVertical) { SetShipOnBoardVertical(ship, i, j); }
            else { SetShipOnBoardHorizontal(ship, i, j); }
        }

        private void SetShipOnBoardHorizontal(Ship ship, int i, int j)
        {
            for (int col = j; col < j + ship.Size; col++)
            {
                board.Board2d[i, col] = 1;
                board.IsOccupiedCell[i, col] = true;

                if (i == 0 && j == 0) // top left corner
                {
                    board.IsOccupiedCell[i, col + 1] = true;
                    board.IsOccupiedCell[i + 1, col] = true;
                    board.IsOccupiedCell[i + 1, col + 1] = true;
                }
                else if (i == board.Cells - 1 && j == 0) // bot left corner
                {
                    board.IsOccupiedCell[i - 1, col] = true;
                    board.IsOccupiedCell[i - 1, col + 1] = true;
                    board.IsOccupiedCell[i, col + 1] = true;
                }
                else if (j == 0) // left border edge
                {
                    board.IsOccupiedCell[i - 1, col] = true;
                    board.IsOccupiedCell[i - 1, col + 1] = true;
                    board.IsOccupiedCell[i + 1, col] = true;
                    board.IsOccupiedCell[i, col + 1] = true;
                    board.IsOccupiedCell[i + 1, col + 1] = true;
                }
                else if (i == 0 && j + ship.Size == board.Cells) // top right corner
                {
                    board.IsOccupiedCell[i, col - 1] = true;
                    board.IsOccupiedCell[i + 1, col - 1] = true;
                    board.IsOccupiedCell[i + 1, col] = true;
                }
                else if (i == board.Cells - 1 && j + ship.Size == board.Cells) // bot right corner
                {
                    board.IsOccupiedCell[i - 1, col] = true;
                    board.IsOccupiedCell[i - 1, col - 1] = true;
                    board.IsOccupiedCell[i, col - 1] = true;
                }
                else if (j + ship.Size == board.Cells) // right border edge
                {
                    board.IsOccupiedCell[i - 1, col] = true;
                    board.IsOccupiedCell[i - 1, col - 1] = true;
                    board.IsOccupiedCell[i + 1, col] = true;
                    board.IsOccupiedCell[i, col - 1] = true;
                    board.IsOccupiedCell[i + 1, col - 1] = true;
                }
                else if (i == 0) // top border edge
                {
                    board.IsOccupiedCell[i, col - 1] = true;
                    board.IsOccupiedCell[i, col + 1] = true;
                    board.IsOccupiedCell[i + 1, col - 1] = true;
                    board.IsOccupiedCell[i + 1, col] = true;
                    board.IsOccupiedCell[i + 1, col + 1] = true;
                }
                else if (i == board.Cells - 1) // bot border edge
                {
                    board.IsOccupiedCell[i - 1, col] = true;
                    board.IsOccupiedCell[i - 1, col - 1] = true;
                    board.IsOccupiedCell[i - 1, col + 1] = true;
                    board.IsOccupiedCell[i, col - 1] = true;
                    board.IsOccupiedCell[i, col + 1] = true;
                }
                else // regular ship placement in the middle of the board
                {
                    board.IsOccupiedCell[i - 1, col] = true;
                    board.IsOccupiedCell[i - 1, col - 1] = true;
                    board.IsOccupiedCell[i - 1, col + 1] = true;
                    board.IsOccupiedCell[i, col - 1] = true;
                    board.IsOccupiedCell[i, col + 1] = true;
                    board.IsOccupiedCell[i + 1, col + 1] = true;
                    board.IsOccupiedCell[i + 1, col - 1] = true;
                    board.IsOccupiedCell[i + 1, col] = true;
                }
            }
        }
        private void SetShipOnBoardVertical(Ship ship, int i, int j)
        {
            for (int row = i; row < i + ship.Size; row++)
            {
                board.Board2d[row, j] = 1;
                board.IsOccupiedCell[row, j] = true;

                if (i == 0 && j == 0) // top left corner
                {
                    board.IsOccupiedCell[row + 1, j] = true;
                    board.IsOccupiedCell[row, j + 1] = true;
                    board.IsOccupiedCell[row + 1, j + 1] = true;
                }
                else if (i + ship.Size == board.Cells && j == 0) // bot left corner
                {
                    board.IsOccupiedCell[row - 1, j] = true;
                    board.IsOccupiedCell[row - 1, j + 1] = true;
                    board.IsOccupiedCell[row, j + 1] = true;
                }
                else if (j == 0) // left border edge
                {
                    board.IsOccupiedCell[row - 1, j] = true;
                    board.IsOccupiedCell[row - 1, j + 1] = true;
                    board.IsOccupiedCell[row + 1, j] = true;
                    board.IsOccupiedCell[row, j + 1] = true;
                    board.IsOccupiedCell[row + 1, j + 1] = true;
                }
                else if (i == 0 && j == board.Cells - 1) // top right corner
                {
                    board.IsOccupiedCell[row, j - 1] = true;
                    board.IsOccupiedCell[row + 1, j - 1] = true;
                    board.IsOccupiedCell[row + 1, j] = true;
                }
                else if (i + ship.Size == board.Cells && j == board.Cells - 1) // bot right corner
                {
                    board.IsOccupiedCell[row - 1, j] = true;
                    board.IsOccupiedCell[row - 1, j - 1] = true;
                    board.IsOccupiedCell[row, j - 1] = true;
                }
                else if (j == board.Cells - 1) // ritgh border edge
                {
                    board.IsOccupiedCell[row - 1, j] = true;
                    board.IsOccupiedCell[row - 1, j - 1] = true;
                    board.IsOccupiedCell[row + 1, j] = true;
                    board.IsOccupiedCell[row, j - 1] = true;
                    board.IsOccupiedCell[row + 1, j - 1] = true;
                }
                else if (i == 0) // top border edge
                {
                    board.IsOccupiedCell[row, j - 1] = true;
                    board.IsOccupiedCell[row, j + 1] = true;
                    board.IsOccupiedCell[row + 1, j - 1] = true;
                    board.IsOccupiedCell[row + 1, j] = true;
                    board.IsOccupiedCell[row + 1, j + 1] = true;
                }
                else if (i + ship.Size == board.Cells) // bot border edge
                {
                    board.IsOccupiedCell[row - 1, j] = true;
                    board.IsOccupiedCell[row - 1, j - 1] = true;
                    board.IsOccupiedCell[row - 1, j + 1] = true;
                    board.IsOccupiedCell[row, j - 1] = true;
                    board.IsOccupiedCell[row, j + 1] = true;
                }
                else // regular ship placement in the middle of the board
                {
                    board.IsOccupiedCell[row - 1, j] = true;
                    board.IsOccupiedCell[row - 1, j - 1] = true;
                    board.IsOccupiedCell[row - 1, j + 1] = true;
                    board.IsOccupiedCell[row, j - 1] = true;
                    board.IsOccupiedCell[row, j + 1] = true;
                    board.IsOccupiedCell[row + 1, j + 1] = true;
                    board.IsOccupiedCell[row + 1, j - 1] = true;
                    board.IsOccupiedCell[row + 1, j] = true;
                }
            }
        }
        private void SetCellPictureBoxColor(Ship ship, int i, int j)
        {
            if (!rotateCheckBox.Checked) { SetCellPictureBoxColorHorizontal(ship, i, j); }
            else if (rotateCheckBox.Checked) { SetCellPictureBoxColorVertical(ship, i, j); }
        }
        private void SetCellPictureBoxColorVertical(Ship ship, int i, int j)
        {
            switch (ship.Size)
            {
                case 1:
                    {
                        foreach (Control control in cellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Green; }
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Control control in cellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i + 1}:{j}") { nextCellPictureBox.BackColor = Color.Green; }
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (Control control in cellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i + 1}:{j}") { nextCellPictureBox.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox2 && nextCellPictureBox2.Tag.ToString() == $"{i + 2}:{j}") { nextCellPictureBox2.BackColor = Color.Green; }
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (Control control in cellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i + 1}:{j}") { nextCellPictureBox.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox2 && nextCellPictureBox2.Tag.ToString() == $"{i + 2}:{j}") { nextCellPictureBox2.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox3 && nextCellPictureBox3.Tag.ToString() == $"{i + 3}:{j}") { nextCellPictureBox3.BackColor = Color.Green; }
                        }
                        break;
                    }
            }
        }
        private void SetCellPictureBoxColorHorizontal(Ship ship, int i, int j)
        {
            switch (ship.Size)
            {
                case 1:
                    {
                        foreach (Control control in cellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Green; }
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Control control in cellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i}:{j + 1}") { nextCellPictureBox.BackColor = Color.Green; }
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (Control control in cellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i}:{j + 1}") { nextCellPictureBox.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox2 && nextCellPictureBox2.Tag.ToString() == $"{i}:{j + 2}") { nextCellPictureBox2.BackColor = Color.Green; }
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (Control control in cellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i}:{j + 1}") { nextCellPictureBox.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox2 && nextCellPictureBox2.Tag.ToString() == $"{i}:{j + 2}") { nextCellPictureBox2.BackColor = Color.Green; }
                            else if (control is PictureBox nextCellPictureBox3 && nextCellPictureBox3.Tag.ToString() == $"{i}:{j + 3}") { nextCellPictureBox3.BackColor = Color.Green; }
                        }
                        break;
                    }
            }
        }
        private void SetShipPosXY(Ship ship, int i, int j)
        {
            if (!rotateCheckBox.Checked) { SetShipPosXYHorizontal(ship, i, j); }
            else if (rotateCheckBox.Checked) { SetShipPosXYVertical(ship, i, j); }
        }
        private void SetShipPosXYVertical(Ship ship, int i, int j)
        {
            switch (ship.Size)
            {
                case 1:
                    {
                        ship.PosX = new int[] { i };
                        ship.PosY = new int[] { j };
                        ship.IsVertical = true;
                        player.BriggSet--;
                        break;
                    }
                case 2:
                    {
                        ship.PosX = new int[] { i, i + 1 };
                        ship.PosY = new int[] { j, j };
                        ship.IsVertical = true;
                        player.CorvetteSet--;
                        break;
                    }
                case 3:
                    {
                        ship.PosX = new int[] { i, i + 1, i + 2 };
                        ship.PosY = new int[] { j, j, j };
                        ship.IsVertical = true;
                        player.FregateSet--;
                        break;
                    }
                case 4:
                    {
                        ship.PosX = new int[] { i, i + 1, i + 2, i + 3 };
                        ship.PosY = new int[] { j, j, j, j };
                        ship.IsVertical = true;
                        player.LincoreSet--;
                        break;
                    }
            }
        }
        private void SetShipPosXYHorizontal(Ship ship, int i, int j)
        {
            switch (ship.Size)
            {
                case 1:
                    {
                        ship.PosX = new int[] { i };
                        ship.PosY = new int[] { j };
                        player.BriggSet--;
                        break;
                    }
                case 2:
                    {
                        ship.PosX = new int[] { i, i };
                        ship.PosY = new int[] { j, j + 1 };
                        player.CorvetteSet--;
                        break;
                    }
                case 3:
                    {
                        ship.PosX = new int[] { i, i, i };
                        ship.PosY = new int[] { j, j + 1, j + 2 };
                        player.FregateSet--;
                        break;
                    }
                case 4:
                    {
                        ship.PosX = new int[] { i, i, i, i };
                        ship.PosY = new int[] { j, j + 1, j + 2, j + 3 };
                        player.LincoreSet--;
                        break;
                    }
            }
        }
    }
}