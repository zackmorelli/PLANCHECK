using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PLANCHECK
{
    public partial class simpleGUI : Form
    {
        public simpleGUI(CancellationToken CancelToken)
        {
            InitializeComponent();

            progbar.Style = ProgressBarStyle.Marquee;
            progbar.Visible = true;
            progbar.MarqueeAnimationSpeed = 100;

            if(CancelToken.IsCancellationRequested)
            {
                this.Close();
            }

        }
    }
}
