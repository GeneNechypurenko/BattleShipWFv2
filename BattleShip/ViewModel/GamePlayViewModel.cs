using BattleShip.Models;
using BattleShip.View;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.ViewModel
{
    public class GamePlayViewModel
    {
        private Player player;
        private Player computer;
        private GamePlayUserControl gamePlay;
        private MainForm mainForm;

        public GamePlayViewModel(Player player, Player computer, GamePlayUserControl gamePlay)
        {
            this.player = player;
            this.computer = computer;
            this.gamePlay = gamePlay;
            //this.mainForm = mainForm;
        }
        public void FirstTurnRoll()
        {
            Random rnd = new Random();

            int result = rnd.Next(0, 2);

            player.IsTurn = (result == 0);
            computer.IsTurn = (result == 1);

            if (player.IsTurn)
            {
                gamePlay.PlayerTurnLabel.Text = "YOUR TURN NOW!";
                gamePlay.ComputerTurnLabel.Text = "";
            }
            else if (computer.IsTurn)
            {
                gamePlay.PlayerTurnLabel.Text = "";
                gamePlay.ComputerTurnLabel.Text = "COMPUTER TURN!";
            }
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
        public async void PerformComputerMove()
        {
            Random rnd = new Random();

            int targetX;
            int targetY;

            bool shotPerformed = false;

            do
            {
                targetX = rnd.Next(0, 10);
                targetY = rnd.Next(0, 10);

                if (player.Board.Board2d[targetX, targetY] != 2)
                {
                    PictureBox targetPictureBox = GetPictureBoxByCoordinates(targetX, targetY);

                    if (targetPictureBox != null)
                    {
                        await Task.Delay(2000);
                        BoardRenderer.Shot(player, targetPictureBox, Color.DarkSlateGray, Color.LimeGreen);
                        shotPerformed = true;
                    }
                }
            } while (!shotPerformed);

            PassTurn();
        }

        private PictureBox GetPictureBoxByCoordinates(int x, int y)
        {
            foreach (Control control in gamePlay.PlayerFlowLayoutPanel.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    string[] coordinates = pictureBox.Tag.ToString().Split(':');
                    if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int i) && int.TryParse(coordinates[1], out int j))
                    {
                        if (i == x && j == y)
                        {
                            return pictureBox;
                        }
                    }
                }
            }
            return null;
        }
    }
}
