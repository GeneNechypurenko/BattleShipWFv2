using BattleShip.Models;
using BattleShip.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.ViewModel
{
    public class ShipSetupViewModel
    {
        private Player player;
        private Player computer;
        private ShipsSetupUserControl shipSetup;
        private MainForm mainForm;

        public ShipSetupViewModel(Player player, Player computer, ShipsSetupUserControl shipSetup, MainForm mainForm)
        {
            this.mainForm = mainForm;
            this.shipSetup = shipSetup;
            this.player = player;
            this.computer = computer;
        }
        public void InitiateComputersShips(Player computer)
        {
            computer.Board.Ships = new ObservableCollection<Ship>
            {
                new Ship {Size = 4},
                new Ship {Size = 3},
                new Ship {Size = 3},
                new Ship {Size = 2},
                new Ship {Size = 2},
                new Ship {Size = 2},
                new Ship {Size = 1},
                new Ship {Size = 1},
                new Ship {Size = 1},
                new Ship {Size = 1},
            };
        }
        public void SetComputerBoard(Player computer)
        {
            InitiateComputersShips(computer);

            Random rand = new Random();
            int currentShip = 0;

            while (currentShip < computer.ShipCount)
            {
                int x;
                int y;
                bool isVertical;

                do
                {
                    x = rand.Next(0, 9);
                    y = rand.Next(0, 9);
                    isVertical = rand.Next(0, 1) == 0 ? false : true;
                } while (computer.Board.IsOccupiedCell[x,y]);

                computer.Board.Ships[currentShip].IsVertical = isVertical;

                SetShipPosXY(computer, computer.Board.Ships[currentShip], x, y);
                SetShipOnBoard(computer, computer.Board.Ships[currentShip], x, y);

                currentShip++;
            }
        }
        public void SetPlayerShip(Player player, PictureBox? clickedPictureBox)
        {
            if (shipSetup.LincoreRadioButton.Checked && player.LincoreSet != 0)
            {
                Ship ship = new Ship { Size = 4, IsSunk = false, IsVertical = false };
                PlacePlayerShipOnBoard(player, ship, clickedPictureBox);
                if (player.LincoreSet == 0) { shipSetup.LincoreRadioButton.Enabled = false; }
            }
            else if (shipSetup.FregateRadioButton.Checked && player.FregateSet != 0)
            {
                Ship ship = new Ship { Size = 3, IsSunk = false, IsVertical = false };
                PlacePlayerShipOnBoard(player, ship, clickedPictureBox);
                if (player.FregateSet == 0) { shipSetup.FregateRadioButton.Enabled = false; }
            }
            else if (shipSetup.CorvetteRadioButton.Checked && player.CorvetteSet != 0)
            {
                Ship ship = new Ship { Size = 2, IsSunk = false, IsVertical = false };
                PlacePlayerShipOnBoard(player, ship, clickedPictureBox);
                if (player.CorvetteSet == 0) { shipSetup.CorvetteRadioButton.Enabled = false; }
            }
            else if (shipSetup.BriggRadioButton.Checked && player.BriggSet != 0)
            {
                Ship ship = new Ship { Size = 1, IsSunk = false, IsVertical = false };
                PlacePlayerShipOnBoard(player, ship, clickedPictureBox);
                if (player.BriggSet == 0) { shipSetup.BriggRadioButton.Enabled = false; }
            }
        }

        private void PlacePlayerShipOnBoard(Player player, Ship ship, PictureBox? clickedPictureBox)
        {
            string[] coordinates = clickedPictureBox.Tag.ToString().Split(':');

            if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int i) && int.TryParse(coordinates[1], out int j))
            {
                if (j <= player.Board.Cells - ship.Size && !shipSetup.RotateCheckBox.Checked && !player.Board.IsOccupiedCell[i, j] && !player.Board.IsOccupiedCell[i, j + ship.Size - 1] ||
                    i <= player.Board.Cells - ship.Size && shipSetup.RotateCheckBox.Checked && !player.Board.IsOccupiedCell[i, j] && !player.Board.IsOccupiedCell[i + ship.Size - 1, j])
                {
                    SetShipPosXY(player, ship, i, j);
                    SetCellPictureBoxColor(ship, i, j);
                    SetShipOnBoard(player, ship, i, j);

                    player.Board.Ships.Add(ship);

                    shipSetup.NotificationLabel.ForeColor = Color.LimeGreen;
                    shipSetup.NotificationLabel.Text = "SHIP PLACED!";

                    if (player.LincoreSet == 0 && player.FregateSet == 0 && player.CorvetteSet == 0 && player.BriggSet == 0)
                    {
                        mainForm.StartGameButton.Enabled = true;
                    }
                }
                else
                {
                    shipSetup.NotificationLabel.ForeColor = Color.Crimson;
                    shipSetup.NotificationLabel.Text = "CAN'T PLACE SHIP THERE!";
                }
            }
        }
        private void SetShipOnBoard(Player player, Ship ship, int i, int j)
        {
            if (ship.IsVertical) { SetShipOnBoardVertical(player, ship, i, j); }
            else { SetShipOnBoardHorizontal(player, ship, i, j); }
        }

        private void SetShipOnBoardHorizontal(Player player, Ship ship, int i, int j)
        {
            for (int col = j; col < j + ship.Size; col++)
            {
                player.Board.Board2d[i, col] = 1;
                player.Board.IsOccupiedCell[i, col] = true;

                if (i == 0 && j == 0) // top left corner
                {
                    player.Board.IsOccupiedCell[i, col + 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col] = true;
                    player.Board.IsOccupiedCell[i + 1, col + 1] = true;
                }
                else if (i == player.Board.Cells - 1 && j == 0) // bot left corner
                {
                    player.Board.IsOccupiedCell[i - 1, col] = true;
                    player.Board.IsOccupiedCell[i - 1, col + 1] = true;
                    player.Board.IsOccupiedCell[i, col + 1] = true;
                }
                else if (j == 0) // left border edge
                {
                    player.Board.IsOccupiedCell[i - 1, col] = true;
                    player.Board.IsOccupiedCell[i - 1, col + 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col] = true;
                    player.Board.IsOccupiedCell[i, col + 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col + 1] = true;
                }
                else if (i == 0 && j + ship.Size == player.Board.Cells) // top right corner
                {
                    player.Board.IsOccupiedCell[i, col - 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col - 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col] = true;
                }
                else if (i == player.Board.Cells - 1 && j + ship.Size == player.Board.Cells) // bot right corner
                {
                    player.Board.IsOccupiedCell[i - 1, col] = true;
                    player.Board.IsOccupiedCell[i - 1, col - 1] = true;
                    player.Board.IsOccupiedCell[i, col - 1] = true;
                }
                else if (j + ship.Size == player.Board.Cells) // right border edge
                {
                    player.Board.IsOccupiedCell[i - 1, col] = true;
                    player.Board.IsOccupiedCell[i - 1, col - 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col] = true;
                    player.Board.IsOccupiedCell[i, col - 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col - 1] = true;
                }
                else if (i == 0) // top border edge
                {
                    player.Board.IsOccupiedCell[i, col - 1] = true;
                    player.Board.IsOccupiedCell[i, col + 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col - 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col] = true;
                    player.Board.IsOccupiedCell[i + 1, col + 1] = true;
                }
                else if (i == player.Board.Cells - 1) // bot border edge
                {
                    player.Board.IsOccupiedCell[i - 1, col] = true;
                    player.Board.IsOccupiedCell[i - 1, col - 1] = true;
                    player.Board.IsOccupiedCell[i - 1, col + 1] = true;
                    player.Board.IsOccupiedCell[i, col - 1] = true;
                    player.Board.IsOccupiedCell[i, col + 1] = true;
                }
                else // regular ship placement in the middle of the board
                {
                    player.Board.IsOccupiedCell[i - 1, col] = true;
                    player.Board.IsOccupiedCell[i - 1, col - 1] = true;
                    player.Board.IsOccupiedCell[i - 1, col + 1] = true;
                    player.Board.IsOccupiedCell[i, col - 1] = true;
                    player.Board.IsOccupiedCell[i, col + 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col + 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col - 1] = true;
                    player.Board.IsOccupiedCell[i + 1, col] = true;
                }
            }
        }
        private void SetShipOnBoardVertical(Player player, Ship ship, int i, int j)
        {
            for (int row = i; row < i + ship.Size; row++)
            {
                player.Board.Board2d[row, j] = 1;
                player.Board.IsOccupiedCell[row, j] = true;

                if (i == 0 && j == 0) // top left corner
                {
                    player.Board.IsOccupiedCell[row + 1, j] = true;
                    player.Board.IsOccupiedCell[row, j + 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j + 1] = true;
                }
                else if (i + ship.Size == player.Board.Cells && j == 0) // bot left corner
                {
                    player.Board.IsOccupiedCell[row - 1, j] = true;
                    player.Board.IsOccupiedCell[row - 1, j + 1] = true;
                    player.Board.IsOccupiedCell[row, j + 1] = true;
                }
                else if (j == 0) // left border edge
                {
                    player.Board.IsOccupiedCell[row - 1, j] = true;
                    player.Board.IsOccupiedCell[row - 1, j + 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j] = true;
                    player.Board.IsOccupiedCell[row, j + 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j + 1] = true;
                }
                else if (i == 0 && j == player.Board.Cells - 1) // top right corner
                {
                    player.Board.IsOccupiedCell[row, j - 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j - 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j] = true;
                }
                else if (i + ship.Size == player.Board.Cells && j == player.Board.Cells - 1) // bot right corner
                {
                    player.Board.IsOccupiedCell[row - 1, j] = true;
                    player.Board.IsOccupiedCell[row - 1, j - 1] = true;
                    player.Board.IsOccupiedCell[row, j - 1] = true;
                }
                else if (j == player.Board.Cells - 1) // ritgh border edge
                {
                    player.Board.IsOccupiedCell[row - 1, j] = true;
                    player.Board.IsOccupiedCell[row - 1, j - 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j] = true;
                    player.Board.IsOccupiedCell[row, j - 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j - 1] = true;
                }
                else if (i == 0) // top border edge
                {
                    player.Board.IsOccupiedCell[row, j - 1] = true;
                    player.Board.IsOccupiedCell[row, j + 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j - 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j] = true;
                    player.Board.IsOccupiedCell[row + 1, j + 1] = true;
                }
                else if (i + ship.Size == player.Board.Cells) // bot border edge
                {
                    player.Board.IsOccupiedCell[row - 1, j] = true;
                    player.Board.IsOccupiedCell[row - 1, j - 1] = true;
                    player.Board.IsOccupiedCell[row - 1, j + 1] = true;
                    player.Board.IsOccupiedCell[row, j - 1] = true;
                    player.Board.IsOccupiedCell[row, j + 1] = true;
                }
                else // regular ship placement in the middle of the board
                {
                    player.Board.IsOccupiedCell[row - 1, j] = true;
                    player.Board.IsOccupiedCell[row - 1, j - 1] = true;
                    player.Board.IsOccupiedCell[row - 1, j + 1] = true;
                    player.Board.IsOccupiedCell[row, j - 1] = true;
                    player.Board.IsOccupiedCell[row, j + 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j + 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j - 1] = true;
                    player.Board.IsOccupiedCell[row + 1, j] = true;
                }
            }
        }
        private void SetCellPictureBoxColor(Ship ship, int i, int j)
        {
            if (!shipSetup.RotateCheckBox.Checked) { SetCellPictureBoxColorHorizontal(ship, i, j); }
            else if (shipSetup.RotateCheckBox.Checked) { SetCellPictureBoxColorVertical(ship, i, j); }
        }
        private void SetCellPictureBoxColorVertical(Ship ship, int i, int j)
        {
            switch (ship.Size)
            {
                case 1:
                    {
                        foreach (Control control in shipSetup.CellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Black; }
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Control control in shipSetup.CellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i + 1}:{j}") { nextCellPictureBox.BackColor = Color.Black; }
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (Control control in shipSetup.CellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i + 1}:{j}") { nextCellPictureBox.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox2 && nextCellPictureBox2.Tag.ToString() == $"{i + 2}:{j}") { nextCellPictureBox2.BackColor = Color.Black; }
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (Control control in shipSetup.CellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i + 1}:{j}") { nextCellPictureBox.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox2 && nextCellPictureBox2.Tag.ToString() == $"{i + 2}:{j}") { nextCellPictureBox2.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox3 && nextCellPictureBox3.Tag.ToString() == $"{i + 3}:{j}") { nextCellPictureBox3.BackColor = Color.Black; }
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
                        foreach (Control control in shipSetup.CellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Black; }
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Control control in shipSetup.CellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i}:{j + 1}") { nextCellPictureBox.BackColor = Color.Black; }
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (Control control in shipSetup.CellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i}:{j + 1}") { nextCellPictureBox.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox2 && nextCellPictureBox2.Tag.ToString() == $"{i}:{j + 2}") { nextCellPictureBox2.BackColor = Color.Black; }
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (Control control in shipSetup.CellsFlowLayoutPanel.Controls)
                        {
                            if (control is PictureBox cellPictureBox && cellPictureBox.Tag.ToString() == $"{i}:{j}") { cellPictureBox.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox && nextCellPictureBox.Tag.ToString() == $"{i}:{j + 1}") { nextCellPictureBox.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox2 && nextCellPictureBox2.Tag.ToString() == $"{i}:{j + 2}") { nextCellPictureBox2.BackColor = Color.Black; }
                            else if (control is PictureBox nextCellPictureBox3 && nextCellPictureBox3.Tag.ToString() == $"{i}:{j + 3}") { nextCellPictureBox3.BackColor = Color.Black; }
                        }
                        break;
                    }
            }
        }
        private void SetShipPosXY(Player player, Ship ship, int i, int j)
        {
            if (!shipSetup.RotateCheckBox.Checked) { SetShipPosXYHorizontal(player, ship, i, j); }
            else if (shipSetup.RotateCheckBox.Checked) { SetShipPosXYVertical(player, ship, i, j); }
        }
        private void SetShipPosXYVertical(Player player, Ship ship, int i, int j)
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
        private void SetShipPosXYHorizontal(Player player, Ship ship, int i, int j)
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