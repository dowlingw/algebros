using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Algebros.Application
{
    public partial class StatScreen : Form
    {
        private List<GameQuestion> questions;

        public StatScreen(List<GameQuestion> askedQuestions, int timePerQ, int difficulty)
        {
            InitializeComponent();
            questions = askedQuestions;
            dataGridView1.DataSource = questions;

            ConfigureDataGridView();

            CalculateStats(timePerQ,difficulty);
        }

        private void CalculateStats(int timePerQ, int difficulty)
        {
            lblDifficulty.Text = difficulty.ToString();
            lblNumberQ.Text = questions.Count.ToString();
            lblTimePerQ.Text = timePerQ.ToString();

            double score = (questions.Where(q => q.AnsweredCorrectly).Count()/questions.Count)*1000;

            lblScore.Text = score.ToString();
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.Columns["Equation"].Visible = false;
            dataGridView1.Columns["Image"].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoResizeColumn(0);
        }
    }
}
