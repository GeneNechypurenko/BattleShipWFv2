using BattleShip.Models;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.ViewModel
{
    public static class BoardRenderer
    {
        private static readonly int _cells = 10;
        private static readonly int _cellSize = 30;
        public static void AddPictureBoxes(FlowLayoutPanel cellsFlowLayoutPanel, Color color, EventHandler CellPictureBox_Click)
        {
            for (int i = 0; i < _cells; ++i)
            {
                for (int j = 0; j < _cells; ++j)
                {
                    PictureBox cellPictureBox = new PictureBox
                    {
                        Size = new Size(_cellSize, _cellSize),
                        Margin = new Padding(0),
                        Location = new Point(i * _cellSize, j * _cellSize),
                        Tag = $"{i}:{j}",
                        BackColor = color,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    cellsFlowLayoutPanel.Controls.Add(cellPictureBox);
                    cellPictureBox.Click += CellPictureBox_Click;
                }
            }
        }

        public static void DrawBorderSideString(int xOffset, int yOffset, Brush color, Graphics g, Font font)
        {
            string leftString = "1234567890";

            foreach (var digit in leftString)
            {
                yOffset += _cellSize;
                g.DrawString(digit.ToString(), font, color, new PointF(xOffset + _cellSize / 4, yOffset + _cellSize / 4));
            }
        }
        public static void DrawBorderTopString(int xOffset, int yOffset, Brush color, Graphics g, Font font)
        {
            string topString = "RESPUBLICA";

            foreach (var letter in topString)
            {
                xOffset += _cellSize;
                g.DrawString(letter.ToString(), font, color, new PointF(xOffset + _cellSize / 4, yOffset + _cellSize / 4));
            }
        }
        public static void SetPlayerBoard(Player player, FlowLayoutPanel playerFlowLayoutPanel, Color color)
        {
            foreach (Control control in playerFlowLayoutPanel.Controls)
            {
                if (control is PictureBox cellPictureBox)
                {
                    string[] coordinates = cellPictureBox.Tag.ToString().Split(':');
                    if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int i) && int.TryParse(coordinates[1], out int j))
                    {
                        if (player.Board.Board2d[i, j] == 1)
                        {
                            cellPictureBox.BackColor = color;
                        }
                    }
                }
            }
        }

        public static void Shot(Player player, PictureBox clickedPictureBox, Color markColor, Color restoreBoardColor)
        {
            string[] coordinates = clickedPictureBox.Tag.ToString().Split(':');
            Font font = new Font("Segoe UI", 32, FontStyle.Bold);

            if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int i) && int.TryParse(coordinates[1], out int j))
            {
                if (player.Board.Board2d[i, j] == 1)
                {
                    clickedPictureBox.Image = CreateMarkedImage(markColor, restoreBoardColor, "⨯", font, clickedPictureBox.Width, clickedPictureBox.Height);
                }
                else if (player.Board.Board2d[i, j] == 0)
                {
                    clickedPictureBox.Image = CreateMarkedImage(markColor, restoreBoardColor, "∙", font, clickedPictureBox.Width, clickedPictureBox.Height);
                }
                player.Board.Board2d[i, j] = 2;
            }
        }

        private static Bitmap CreateMarkedImage(Color markColor, Color restoreBoardColor, string mark, Font font, int width, int height)
        {
            Bitmap image = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(restoreBoardColor);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                using (Brush brush = new SolidBrush(markColor))
                {
                    g.DrawString(mark, font, brush, new PointF((width - g.MeasureString(mark, font).Width) / 2, (height - g.MeasureString(mark, font).Height) / 2 - 3));
                }
            }

            return image;
        }
    }
}
