using BattleShip.Models;
using BattleShip.View;

namespace BattleShip.ViewModel
{
    public class GamePlayViewModel
    {
        private Player player;
        private Player computer;
        private GamePlayUserControl gamePlay;
        private MainForm mainForm;
        private EndGameScreenForm endGameScreen;

        public GamePlayViewModel(Player player, Player computer, GamePlayUserControl gamePlay)
        {
            this.player = player;
            this.computer = computer;
            this.gamePlay = gamePlay;
            this.mainForm = mainForm;
            endGameScreen = new EndGameScreenForm();
        }
        public void PerformPlayerMove(Player computer, PictureBox clickedPictureBox, FlowLayoutPanel cellsFlowLayoutPanel, Color markColor, Color restoreBoardColor)
        {
            string[] coordinates = clickedPictureBox.Tag.ToString().Split(':');

            if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int i) && int.TryParse(coordinates[1], out int j))
            {
                PerformShot(computer, i, j, clickedPictureBox, markColor, restoreBoardColor);
            }
        }
        public async Task PerformComputerMove(Player player, FlowLayoutPanel cellsFlowLayoutPanel, Color markColor, Color restoreBoardColor)
        {
            Random rnd = new Random();

            int targetX;
            int targetY;

            do
            {
                targetX = rnd.Next(0, 10);
                targetY = rnd.Next(0, 10);

                if (player.Board.Board2d[targetX, targetY] != 2)
                {
                    await Task.Delay(1500);
                    MarkPictureBoxByCoordinates(player, cellsFlowLayoutPanel, targetX, targetY, markColor, restoreBoardColor);
                }
            } while (!player.IsTurn);
        }
        private void PerformShot(Player computer, int i, int j, PictureBox clickedPictureBox, Color markColor, Color restoreBoardColor)
        {
            Font font = new Font("Segoe UI", 32, FontStyle.Bold);

            if (computer.Board.Board2d[i, j] == 1)
            {
                clickedPictureBox.Image = BoardRenderer.CreateMarkedImage(markColor, restoreBoardColor, "⨯", font, clickedPictureBox.Width, clickedPictureBox.Height);
                if (CheckIsSunk(computer, i, j))
                {
                    computer.ShipCount--;
                    CheckEndGameConditions();
                }
            }
            else if (computer.Board.Board2d[i, j] == 0)
            {
                clickedPictureBox.Image = BoardRenderer.CreateMarkedImage(markColor, restoreBoardColor, "∙", font, clickedPictureBox.Width, clickedPictureBox.Height);
                PassTurn();
            }
            computer.Board.Board2d[i, j] = 2;
        }
        private void MarkPictureBoxByCoordinates(Player player, FlowLayoutPanel cellsFlowLayoutPanel, int x, int y, Color markColor, Color restoreBoardColor)
        {
            foreach (Control control in cellsFlowLayoutPanel.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    string[] coordinates = pictureBox.Tag.ToString().Split(':');

                    if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int i) && int.TryParse(coordinates[1], out int j))
                    {
                        if (i == x && j == y)
                        {
                            PerformShot(player, x, y, pictureBox, markColor, restoreBoardColor);
                        }
                    }
                }
            }
        }
        private bool CheckIsSunk(Player computer, int i, int j)
        {
            foreach (var ship in computer.Board.Ships)
            {
                if (ship.IsVertical)
                {
                    if (i >= ship.PosX[0] && i < ship.PosX[0] + ship.Size && ship.PosY[0] == j)
                    {
                        int hitIndex = i - ship.PosX[0];
                        ship.IsHit[hitIndex] = true;

                        if (ship.IsHit.All(hit => hit))
                        {
                            ship.IsSunk = true;
                        }
                        return ship.IsSunk;
                    }
                }
                else
                {
                    for (int k = 0; k < ship.Size; k++)
                    {
                        if (ship.PosX[k] == i && ship.PosY[k] == j)
                        {
                            ship.IsHit[k] = true;

                            if (ship.IsHit.All(hit => hit))
                            {
                                ship.IsSunk = true;
                            }
                            return ship.IsSunk;
                        }
                    }
                }
            }
            return false;
        }
        public void PassTurn()
        {
            if (player.IsTurn)
            {
                player.IsTurn = false;
                computer.IsTurn = true;
                gamePlay.PlayerTurnLabel.Text = "";
                gamePlay.ComputerTurnLabel.Text = "COMPUTER TURN!";
            }
            else if (computer.IsTurn)
            {
                player.IsTurn = true;
                computer.IsTurn = false;
                gamePlay.PlayerTurnLabel.Text = "YOUR TURN NOW!";
                gamePlay.ComputerTurnLabel.Text = "";
            }
        }
        private void CheckEndGameConditions()
        {
            if (computer.ShipCount == 0)
            {
                endGameScreen.EndGameLabel.Text = "YOU WON THE GAME!";
                endGameScreen.ShowDialog(mainForm);
            }
            else if (player.ShipCount == 0)
            {
                endGameScreen.EndGameLabel.Text = "YOU LOST THE GAME!";
                endGameScreen.ShowDialog(mainForm);
            }
        }
    }
}
