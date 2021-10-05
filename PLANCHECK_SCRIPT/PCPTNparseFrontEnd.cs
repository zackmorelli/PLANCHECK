using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

using PLANCHECK;

namespace PLANCHECK_SCRIPT
{
    public partial class PCPTNparseFrontEnd : Form
    {
        public PCTPNparse parseret = new PCTPNparse();
        public PCPTNparseFrontEnd(string PatientId)
        {
            InitializeComponent();
            MessageBox.Show("PCTPN front end initalized");
            textBox1.FontChanged += (sender, EventArgs) => { textBox1_fontchanged(sender, EventArgs, PatientId); };
            Thread.Sleep(5000);
            this.Refresh();
            this.BringToFront();
            textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        void textBox1_fontchanged(object sender, EventArgs e, string patientId)
        {
            MessageBox.Show("before PCTPNparse task");

          

            Task<PCTPNparse> parset = new Task<PCTPNparse>(() =>
            {
                PCTPNparse initparse = new PCTPNparse(patientId);
                MessageBox.Show("yo");
                return initparse;
            });

            parset.Start();
            parset.Wait();
            MessageBox.Show("After PCTPNparse task");


            //PCTPNparse parset = await Task.Run<PCTPNparse>(() =>
            //{
            //    PCTPNparse initparse = new PCTPNparse(patientId);
            //    MessageBox.Show("yo");
            //    return initparse;
            //});


            parseret = parset.Result;
            this.Close();
        }
    }
}
