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
            for (int i = 0; i < _cells; i++)
            {
                for (int j = 0; j < _cells; j++)
                {
                    if (player.Board.Board2d[i, j] == 1)
                    {
                        int index = i * _cells + j;

                        if (index < playerFlowLayoutPanel.Controls.Count)
                        {
                            if (playerFlowLayoutPanel.Controls[index] is PictureBox cellPictureBox)
                            {
                                cellPictureBox.BackColor = color;
                            }
                        }
                    }
                }
            }
        }
        public static void Shot(Player player, PictureBox clickedPictureBox, Color markColor, Color restoreBoardColor)
        {
            string[] coordinates = clickedPictureBox.Tag.ToString().Split(':');
            Font font = new Font("Segoe UI", 20, FontStyle.Bold);

            if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int i) && int.TryParse(coordinates[1], out int j))
            {
                if (player.Board.Board2d[i, j] == 1)
                {
                    clickedPictureBox.Image = new Bitmap(clickedPictureBox.Width, clickedPictureBox.Height);
                    using (Graphics g = Graphics.FromImage(clickedPictureBox.Image))
                    {
                        using (Brush brush = new SolidBrush(markColor))
                        {
                            clickedPictureBox.BackColor = restoreBoardColor;
                            float x = (clickedPictureBox.Width - g.MeasureString("X", font).Width) / 2;
                            float y = (clickedPictureBox.Height - g.MeasureString("X", font).Height) / 2;
                            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                            g.DrawString("X", font, brush, new PointF(x, y));
                        }
                    }
                }
                else if (player.Board.Board2d[i, j] == 0)
                {
                    clickedPictureBox.Image = new Bitmap(clickedPictureBox.Width, clickedPictureBox.Height);
                    using (Graphics g = Graphics.FromImage(clickedPictureBox.Image))
                    {
                        using (Brush brush = new SolidBrush(markColor))
                        {
                            float x = (clickedPictureBox.Width - g.MeasureString("O", font).Width) / 2;
                            float y = (clickedPictureBox.Height - g.MeasureString("O", font).Height) / 2;
                            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                            g.DrawString("O", font, brush, new PointF(x, y));
                        }
                    }
                }
                player.Board.Board2d[i, j] = 2;
            }
        }
    }
}
