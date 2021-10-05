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
    public partial class DocCheckFrontEnd : Form
    {
        public DocChecks doccheck = new DocChecks();
        public DocCheckFrontEnd(DateTime plancreation, string patientId)
        {
            InitializeComponent();
            textBox1.FontChanged += (sender, EventArgs) => { textBox1_fontchanged(sender, EventArgs, plancreation, patientId); };
            this.Refresh();
            this.BringToFront();
            textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        async void textBox1_fontchanged(object sender, EventArgs e, DateTime plancreation, string patientId)
        {
            DocChecks tdoccheck = await Task.Run<DocChecks>(() =>
            {
                DocChecks initdoccheck = new DocChecks(plancreation, patientId);

                return initdoccheck;
            });

            doccheck = tdoccheck;
            this.Close();
        }




    }
}
