using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip.View
{
    public partial class GamePlayUserControl : UserControl
    {
        private Player player;
        private Board board;
        public GamePlayUserControl(Player player, Board board)
        {
            this.board = board;
            this.player = player;
            InitializeComponent();
            AddPictureBoxes(playerFlowLayoutPanel, Color.LimeGreen);
            AddPictureBoxes(computerFlowLayoutPanel, Color.Crimson);
            Paint += (s, e) =>
            {
                DrawBorderTopString(20, 30, Brushes.LimeGreen);
                DrawBorderLeftString(20, 30, Brushes.LimeGreen);
                DrawBorderTopString(360, 30, Brushes.Crimson);
                DrawBorderLeftString(690, 30, Brushes.Crimson);
            };
        }
        private void AddPictureBoxes(FlowLayoutPanel cellsFlowLayoutPanel, Color color)
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
                        BackColor = color,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    cellsFlowLayoutPanel.Controls.Add(cellPictureBox);
                }
            }
        }
        private void DrawBorderLeftString(int xOffset, int yOffset, Brush color)
        {
            using (Graphics g = CreateGraphics())
            {
                string leftString = "1234567890";

                foreach (var digit in leftString)
                {
                    yOffset += board.CellSize;
                    g.DrawString(digit.ToString(), this.Font, color, new PointF(xOffset + board.CellSize / 4, yOffset + board.CellSize / 4));
                }
            }
        }
        private void DrawBorderTopString(int xOffset, int yOffset, Brush color)
        {
            using (Graphics g = CreateGraphics())
            {
                string topString = "RESPUBLICA";

                foreach (var letter in topString)
                {
                    xOffset += board.CellSize;
                    g.DrawString(letter.ToString(), this.Font, color, new PointF(xOffset + board.CellSize / 4, yOffset + board.CellSize / 4));
                }
            }
        }
    }
}
