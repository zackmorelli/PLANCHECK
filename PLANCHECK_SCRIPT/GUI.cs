using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLANCHECK_SCRIPT
{
    public partial class GUI : Form
    {
        public string[] str = new string[4];
        public GUI(List<string> planids)
        {
            InitializeComponent();

            foreach (string s in planids)
            {
                PlanList.Items.Add(s);
            }
        }

        private void Execute(object sender, EventArgs args)
        {
            str[0] = PlanList.SelectedItem.ToString();
            str[1] = LateralityList.SelectedItem.ToString();
            
            if(SRSCheck.Checked == true)
            {
                str[2] = "true";
            }
            else
            {
                str[2] = "false";
            }


            if (DocCheck.Checked == true)
            {
                str[3] = "true";
            }
            else
            {
                str[3] = "false";
            }

            this.Close();
        }
    }
}
