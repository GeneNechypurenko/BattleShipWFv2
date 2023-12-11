using BattleShip.Models;
using BattleShip.ViewModel;

namespace BattleShip.View
{
    public partial class GamePlayUserControl : UserControl
    {
        private Player player;
        private Player computer;
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
            using (Graphics g = e.Graphics)
            {
                BoardRenderer.DrawBorderTopString(20, 20, Brushes.LimeGreen, e.Graphics, this.Font);
                BoardRenderer.AddPictureBoxes(playerFlowLayoutPanel, Color.LimeGreen, CellPictureBox_Click);
                BoardRenderer.DrawBorderSideString(20, 20, Brushes.LimeGreen, e.Graphics, this.Font);
                BoardRenderer.SetPlayerBoard(player, playerFlowLayoutPanel, Color.DarkSlateGray);

                BoardRenderer.DrawBorderTopString(360, 20, Brushes.Crimson, e.Graphics, this.Font);
                BoardRenderer.AddPictureBoxes(computerFlowLayoutPanel, Color.Crimson, CellPictureBox_Click);
                BoardRenderer.DrawBorderSideString(690, 20, Brushes.Crimson, e.Graphics, this.Font);

                //если раскомментировать покажет расположение кораблей противника на его доске
                //BoardRenderer.SetPlayerBoard(computer, computerFlowLayoutPanel, Color.DarkSlateGray); 
            };
        }
        private void CellPictureBox_Click(object? sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox && computerFlowLayoutPanel.Controls.Contains(clickedPictureBox))
            {
                if (player.IsTurn)
                {
                    viewModel.PerformPlayerMove(computer, clickedPictureBox, computerFlowLayoutPanel, Color.DarkSlateGray, Color.Crimson);
                    if (computer.IsTurn)
                    {
                        viewModel.PerformComputerMove(player, playerFlowLayoutPanel, Color.DarkSlateGray, Color.LimeGreen);
                    }
                }
            }
        }
    }
}