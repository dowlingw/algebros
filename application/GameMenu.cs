using System;
using System.Windows.Forms;

namespace Algebros.Application
{
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();
            UpdateTextValues();
        }

        private void UpdateTextValues()
        {
            lbDifficulty.Text = tbDifficulty.Value.ToString();
            lbNumq.Text = tbNumq.Value.ToString();
            lbTimeper.Text = tbTimeper.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            UpdateTextValues();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateTextValues();
        }

        private void tbDifficulty_Scroll(object sender, EventArgs e)
        {
            UpdateTextValues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gameScreen = new GameScreen(
                tbNumq.Value,
                tbDifficulty.Value,
                tbTimeper.Value
            );

            gameScreen.ShowDialog();
        }

        private void GameMenu_Load(object sender, EventArgs e)
        {
        }

        private void GameMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        
    }
}
