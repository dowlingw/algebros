using System;
using System.Drawing;
using Algebros.Generator;

namespace Algebros.Application
{
    public class GameQuestion
    {
        public String QuestionString { get; set; }
        public Equation Equation { get; set; }
        public bool AnsweredCorrectly { get; set; }
        public int GivenAnswer { get; set; }
        public int ActualAnswer { get; set; }
        public Bitmap Image { get; set; }
        
        public GameQuestion()
        {
            Equation = null;
            QuestionString = null;
            AnsweredCorrectly = false;
            GivenAnswer = 0;
            ActualAnswer = -1;
        }

        public void AssignQuestion( Equation eqn )
        {
            Equation = eqn;
        }
    }
}