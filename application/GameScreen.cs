using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Algebros.Generator;
using System.Linq;

namespace Algebros.Application
{
    public partial class GameScreen : Form
    {
        private List<GameQuestion> askedQuestions;
        private Queue<GameQuestion> pendingQuestions;

        private Form1 loadingForm;

        private int qTime;
        private int gameClock;
        private int gameDifficulty;
        private int _numQuestions;
        private GameQuestion currentQuestion;
        
        public GameScreen(int numQuestions, int difficulty, int questionTime )
        {
            // Do boring stuff
            InitializeComponent();
            loadingForm = new Form1();

            // Set the global question time counter
            gameDifficulty = difficulty;
            qTime = questionTime;
            _numQuestions = numQuestions;
            
            // Launch a thread to generate equations and retrieve images
            var questionGenerator = new BackgroundWorker {WorkerReportsProgress = true};
            questionGenerator.DoWork += GenerateQuestions;
            questionGenerator.ProgressChanged += (sender, args) => loadingForm.SetProgress(args.ProgressPercentage);
            questionGenerator.RunWorkerCompleted += (sender, args) => loadingForm.Hide();
            questionGenerator.RunWorkerAsync();
            loadingForm.ShowDialog();            

            // Set the timer length
            timer1.Tick += Timer1OnTick;
            timer1.Interval = 1000; // one second

            // Run event loop
            FireQuestion();
        }

        private void GenerateQuestions(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            pendingQuestions = new Queue<GameQuestion>();
            askedQuestions = new List<GameQuestion>();
            for (int i = 0; i < _numQuestions ; i++)
            {
                // Generate the game question
                var gameQuestion = new GameQuestion();
                gameQuestion.AssignQuestion(EquationGenerator.GenerateRandomEquation(gameDifficulty));
                CalculateQuestionString(gameQuestion);

                // Get an imaeg
                String imageURL = "http://latex.codecogs.com/png.latex?" + gameQuestion.Equation.AsTeX(false);
                gameQuestion.Image = getImageFromURL(imageURL);

                // Enqueue the image
                pendingQuestions.Enqueue(gameQuestion);

                // Fire an event to show we've made progress
                double progress = ((double)pendingQuestions.Count / (double)_numQuestions) * 100.0;
                (sender as BackgroundWorker).ReportProgress(Convert.ToInt32(progress));
            }
        }

        public Bitmap getImageFromURL(String sURL)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(sURL);
            myRequest.Method = "GET";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
            myResponse.Close();

            return bmp;
        }

        private void Timer1OnTick(object sender, EventArgs eventArgs)
        {
            // Fired every second - update the game clock
            int secsLeft = qTime - ++gameClock;
            label1.Text = secsLeft.ToString();

            // Did we reach 0?
            if( secsLeft <= 0 )
            {
                TimesUp();
            }
        }

        private void TimesUp()
        {
            // Stop the clock
            timer1.Stop();

            // Grab the answer from the form
            int givenAnswer = 0;
            int.TryParse(tbAnswer.Text, out givenAnswer);

            currentQuestion.GivenAnswer = givenAnswer;
            currentQuestion.AnsweredCorrectly = currentQuestion.GivenAnswer.Equals(currentQuestion.ActualAnswer);

            TalkAtme(currentQuestion.AnsweredCorrectly);
            
            // Clear this question off the slate
            askedQuestions.Add(currentQuestion);
            currentQuestion = null;

            // Clear other stuff
            tbAnswer.Text = string.Empty;


            // Fire off another question
            FireQuestion();
        }

        private void TalkAtme(bool answeredCorrectly)
        {
            String talkback = answeredCorrectly ? "Duuuuude!" : "Bro :-(";
            lblKim.Text = talkback;
        }

        private void FireQuestion()
        {
            // Do we have any more questions to ask?
            if( pendingQuestions.Count == 0 )
            {
                FinishedUp();
                this.Close();
                return;
            }

            // Grab a question from the queue
            currentQuestion = pendingQuestions.Dequeue();

            // Set up the screen
            tbAnswer.Text = String.Empty;
            pbQuestion.Image = currentQuestion.Image;   pbQuestion.Refresh();
            //lbQuestion.Text = currentQuestion.QuestionString;
            //Clipboard.SetText(currentQuestion.QuestionString);

            // Fire off the timer
            gameClock = 0;
            label1.Text = qTime.ToString();
            timer1.Start();
        }

        private void CalculateQuestionString(GameQuestion question)
        {
            // Takes the current question, finds one of the fields and blanks it
            // Stores the answer and question string.

            var searchRoot = question.Equation.LHS;
            var leafs = findEquationLeafs(searchRoot);

            var random = new Random();  // random number generator for this
            var componentToHide = leafs.OrderBy(leaf => random.Next()).Take(1).Single();

            // Flag the leaf node as obscured (not shown in question) and render the question as a string
            componentToHide.SetObscured();
            question.QuestionString = question.Equation.ToString();

            // Gank the answer (we dodgily assume its a number here)
            question.ActualAnswer = ((NumberLeaf)componentToHide).Number;
        }

        private List<INode> findEquationLeafs( INode eqn )
        {
            var eqns = new List<INode>();

            foreach (var child in eqn.GetChildren())
            {
                if( child.IsLeaf() )
                {
                    eqns.Add(child);
                }
                else
                {
                    // Recurse!
                    eqns.AddRange(findEquationLeafs(child));
                }
            }

            return eqns;
        }

        private void FinishedUp()
        {
            var statScreen = new StatScreen(askedQuestions,qTime,gameDifficulty);
            statScreen.ShowDialog();
            this.Close();
        }

        private void tbAnswer_KeyUp(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter )
            {
                TimesUp();
            }
        }
    }
}
