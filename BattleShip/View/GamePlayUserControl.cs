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

namespace BattleShip.View
{
    public partial class GamePlayUserControl : UserControl
    {
        private Player player;
        private Player computer;
        public GamePlayUserControl(Player player, Player computer)
        {
            this.player = player;
            this.computer = computer;

            InitializeComponent();
            Paint += GamePlayUserControl_Paint;
        }
        private void GamePlayUserControl_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            BoardRenderer.DrawBorderTopString(20, 30, Brushes.LimeGreen, e.Graphics, this.Font);
            BoardRenderer.AddPictureBoxes(playerFlowLayoutPanel, Color.LimeGreen, CellPictureBox_Click);
            BoardRenderer.DrawBorderSideString(20, 30, Brushes.LimeGreen, e.Graphics, this.Font);
            BoardRenderer.SetPlayerBoard(player, playerFlowLayoutPanel);

            BoardRenderer.DrawBorderTopString(360, 30, Brushes.Crimson, e.Graphics, this.Font);
            BoardRenderer.AddPictureBoxes(computerFlowLayoutPanel, Color.Crimson, CellPictureBox_Click);
            BoardRenderer.DrawBorderSideString(690, 30, Brushes.Crimson, e.Graphics, this.Font);
            BoardRenderer.SetPlayerBoard(computer, computerFlowLayoutPanel);
        }

        private void CellPictureBox_Click(object? sender, EventArgs e)
        {

        }
    }
}