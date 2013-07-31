using System.Windows.Forms;

namespace Algebros.Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void SetProgress( int percent )
        {
            progressBar1.Value = percent;
            this.Refresh();
        }
    }
}
