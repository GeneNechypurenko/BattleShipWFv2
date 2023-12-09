using BattleShip.Models;
using BattleShip.View;

namespace BattleShip
{
    public partial class MainForm : Form
    {
        private ShipsSetupUserControl shipsSetupUserControl;
        private GamePlayUserControl gamePlayUserControl;
        private Button startGameButton;

        private Player player;
        private Player computer;
        public Button StartGameButton { get => startGameButton; }
        public MainForm()
        {
            player = new Player(new Board());
            computer = new Player(new Board());
            InitializeComponent();
            DoubleBuffered = true;
        }
        private void startScreenButton_Click(object sender, EventArgs e)
        {
            RenderScreen();
            shipsSetupUserControl = new ShipsSetupUserControl(this, player, computer);
            Controls.Add(shipsSetupUserControl);
            shipsSetupUserControl.Show();
        }

        private void RenderScreen()
        {
            Controls.Remove(startScreenPanel);
            buttonPanel.Controls.Clear();
            AddButton();
        }

        private void AddButton()
        {
            startGameButton = new Button();
            buttonPanel.Controls.Add(startGameButton);
            startGameButton.FlatStyle = FlatStyle.Flat;
            startGameButton.FlatAppearance.BorderSize = 0;
            startGameButton.Text = "START BATTLE!";
            startGameButton.Dock = DockStyle.Fill;
            startGameButton.Enabled = false;
            startGameButton.Click += (s, e) =>
            {
                Controls.Clear();
                gamePlayUserControl = new GamePlayUserControl(player, computer);
                Controls.Add(gamePlayUserControl);
                gamePlayUserControl.Show();
            };
        }
    }
}