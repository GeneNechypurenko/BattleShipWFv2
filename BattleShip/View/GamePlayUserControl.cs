using BattleShip.Models;
using BattleShip.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace BattleShip.View
{
    public partial class GamePlayUserControl : UserControl
    {
        private Timer computerMoveTimer = new Timer();

        private Player player;
        private Player computer;
        public FlowLayoutPanel PlayerFlowLayoutPanel { get => playerFlowLayoutPanel; }
        public Label PlayerTurnLabel
        {
            get => playerTurnLabel;
            set => playerTurnLabel = value;
        }
        public Label ComputerTurnLabel
        {
            get => computerTurnLabel;
            set => computerTurnLabel = value;
        }

        private GamePlayViewModel viewModel;
        public GamePlayUserControl(Player player, Player computer)
        {
            this.player = player;
            this.computer = computer;
            viewModel = new GamePlayViewModel(player, computer, this);

            InitializeComponent();
            player.IsTurn = true;
            playerTurnLabel.Text = "YOUR TURN NOW!";
            Paint += GamePlayUserControl_Paint;

            Load += (s, e) =>
            {
                playerShipCountLabel.DataBindings.Add("Text", player, "ShipCount");
                computerShipCountLabel.DataBindings.Add("Text", computer, "ShipCount");
            };
        }
        private void GamePlayUserControl_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            BoardRenderer.DrawBorderTopString(20, 20, Brushes.LimeGreen, e.Graphics, this.Font);
            BoardRenderer.AddPictureBoxes(playerFlowLayoutPanel, Color.LimeGreen, CellPictureBox_Click);
            BoardRenderer.DrawBorderSideString(20, 20, Brushes.LimeGreen, e.Graphics, this.Font);
            BoardRenderer.SetPlayerBoard(player, playerFlowLayoutPanel, Color.DarkSlateGray);

            BoardRenderer.DrawBorderTopString(360, 20, Brushes.Crimson, e.Graphics, this.Font);
            BoardRenderer.AddPictureBoxes(computerFlowLayoutPanel, Color.Crimson, CellPictureBox_Click);
            BoardRenderer.DrawBorderSideString(690, 20, Brushes.Crimson, e.Graphics, this.Font);
            //BoardRenderer.SetPlayerBoard(computer, computerFlowLayoutPanel, Color.DarkSlateGray);
        }
        private void CellPictureBox_Click(object? sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                if (player.IsTurn && computerFlowLayoutPanel.Controls.Contains(clickedPictureBox))
                {
                    BoardRenderer.Shot(computer, clickedPictureBox, Color.DarkSlateGray, Color.Crimson);
                    viewModel.PassTurn();
                    viewModel.PerformComputerMove();
                }
            }
        }
    }
}