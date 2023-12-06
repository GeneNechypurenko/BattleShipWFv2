using BattleShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.ViewModel
{
    public static class BoardRenderer
    {
        public static Board board { get; set; } = new Board();
        public static void AddPictureBoxes(FlowLayoutPanel cellsFlowLayoutPanel, Color color)
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
        public static void DrawBorderLeftString(int xOffset, int yOffset, Brush color, Graphics g, Font font)
        {
            string leftString = "1234567890";

            foreach (var digit in leftString)
            {
                yOffset += board.CellSize;
                g.DrawString(digit.ToString(), font, color, new PointF(xOffset + board.CellSize / 4, yOffset + board.CellSize / 4));
            }
        }
        public static void DrawBorderTopString(int xOffset, int yOffset, Brush color, Graphics g, Font font)
        {
            string topString = "RESPUBLICA";

            foreach (var letter in topString)
            {
                xOffset += board.CellSize;
                g.DrawString(letter.ToString(), font, color, new PointF(xOffset + board.CellSize / 4, yOffset + board.CellSize / 4));
            }
        }
    }
}
