namespace BattleShip.View
{
    public partial class EndGameScreenForm : Form
    {
        public Label EndGameLabel { get => endGameLabel; }
        public Button ExitButton { get => exitButton; }
        public EndGameScreenForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
