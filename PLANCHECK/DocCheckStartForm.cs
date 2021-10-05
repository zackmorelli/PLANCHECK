using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLANCHECK
{
    public partial class DocCheckStartForm : Form
    {
        public bool DocCheckSelection = false;
        public DocCheckStartForm()
        {
            InitializeComponent();
        }

        public void SkipButton_Click(object sender, EventArgs e)
        {
            DocCheckSelection = false;

            this.Close();
        }

        public void DocCheckInitButton_Click(object sender, EventArgs e)
        {
            DocCheckSelection = true;

            this.Close();
        }


    }
}
