namespace PLANCHECK_SCRIPT
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.PlanLabel = new System.Windows.Forms.Label();
            this.PlanList = new System.Windows.Forms.ListBox();
            this.LateralityLabel = new System.Windows.Forms.Label();
            this.SRSLabel = new System.Windows.Forms.Label();
            this.LateralityList = new System.Windows.Forms.ListBox();
            this.SRSCheck = new System.Windows.Forms.CheckBox();
            this.DocLabel = new System.Windows.Forms.Label();
            this.DocCheck = new System.Windows.Forms.CheckBox();
            this.DocExplan = new System.Windows.Forms.TextBox();
            this.ExBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlanLabel
            // 
            this.PlanLabel.AutoSize = true;
            this.PlanLabel.Location = new System.Drawing.Point(8, 19);
            this.PlanLabel.Name = "PlanLabel";
            this.PlanLabel.Size = new System.Drawing.Size(495, 20);
            this.PlanLabel.TabIndex = 0;
            this.PlanLabel.Text = "Please select one of the available plans below to run a plan check on.";
            this.PlanLabel.UseMnemonic = false;
            // 
            // PlanList
            // 
            this.PlanList.FormattingEnabled = true;
            this.PlanList.ItemHeight = 20;
            this.PlanList.Location = new System.Drawing.Point(16, 52);
            this.PlanList.Name = "PlanList";
            this.PlanList.Size = new System.Drawing.Size(299, 124);
            this.PlanList.TabIndex = 1;
            // 
            // LateralityLabel
            // 
            this.LateralityLabel.AutoSize = true;
            this.LateralityLabel.Location = new System.Drawing.Point(12, 237);
            this.LateralityLabel.Name = "LateralityLabel";
            this.LateralityLabel.Size = new System.Drawing.Size(188, 20);
            this.LateralityLabel.TabIndex = 2;
            this.LateralityLabel.Text = "Please select a Laterality.";
            this.LateralityLabel.UseMnemonic = false;
            // 
            // SRSLabel
            // 
            this.SRSLabel.AutoSize = true;
            this.SRSLabel.Location = new System.Drawing.Point(12, 191);
            this.SRSLabel.Name = "SRSLabel";
            this.SRSLabel.Size = new System.Drawing.Size(154, 20);
            this.SRSLabel.TabIndex = 3;
            this.SRSLabel.Text = "Is this an SRS plan?";
            this.SRSLabel.UseMnemonic = false;
            // 
            // LateralityList
            // 
            this.LateralityList.FormattingEnabled = true;
            this.LateralityList.ItemHeight = 20;
            this.LateralityList.Items.AddRange(new object[] {
            "Right",
            "Left",
            "NA"});
            this.LateralityList.Location = new System.Drawing.Point(16, 260);
            this.LateralityList.Name = "LateralityList";
            this.LateralityList.Size = new System.Drawing.Size(96, 64);
            this.LateralityList.TabIndex = 4;
            // 
            // SRSCheck
            // 
            this.SRSCheck.AutoSize = true;
            this.SRSCheck.Location = new System.Drawing.Point(172, 197);
            this.SRSCheck.Name = "SRSCheck";
            this.SRSCheck.Size = new System.Drawing.Size(15, 14);
            this.SRSCheck.TabIndex = 5;
            this.SRSCheck.UseVisualStyleBackColor = true;
            // 
            // DocLabel
            // 
            this.DocLabel.AutoSize = true;
            this.DocLabel.Location = new System.Drawing.Point(239, 191);
            this.DocLabel.Name = "DocLabel";
            this.DocLabel.Size = new System.Drawing.Size(193, 20);
            this.DocLabel.TabIndex = 6;
            this.DocLabel.Text = "Include DocumentCheck?";
            this.DocLabel.UseMnemonic = false;
            // 
            // DocCheck
            // 
            this.DocCheck.AutoSize = true;
            this.DocCheck.Location = new System.Drawing.Point(438, 197);
            this.DocCheck.Name = "DocCheck";
            this.DocCheck.Size = new System.Drawing.Size(15, 14);
            this.DocCheck.TabIndex = 7;
            this.DocCheck.UseVisualStyleBackColor = true;
            // 
            // DocExplan
            // 
            this.DocExplan.Location = new System.Drawing.Point(224, 234);
            this.DocExplan.Multiline = true;
            this.DocExplan.Name = "DocExplan";
            this.DocExplan.Size = new System.Drawing.Size(284, 234);
            this.DocExplan.TabIndex = 9;
            this.DocExplan.Text = resources.GetString("DocExplan.Text");
            // 
            // ExBut
            // 
            this.ExBut.Location = new System.Drawing.Point(28, 412);
            this.ExBut.Name = "ExBut";
            this.ExBut.Size = new System.Drawing.Size(128, 56);
            this.ExBut.TabIndex = 10;
            this.ExBut.Text = "Execute";
            this.ExBut.UseVisualStyleBackColor = true;
            this.ExBut.Click += new System.EventHandler(this.Execute);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 487);
            this.Controls.Add(this.ExBut);
            this.Controls.Add(this.DocExplan);
            this.Controls.Add(this.DocCheck);
            this.Controls.Add(this.DocLabel);
            this.Controls.Add(this.SRSCheck);
            this.Controls.Add(this.LateralityList);
            this.Controls.Add(this.SRSLabel);
            this.Controls.Add(this.LateralityLabel);
            this.Controls.Add(this.PlanList);
            this.Controls.Add(this.PlanLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GUI";
            this.Text = "PlanCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlanLabel;
        private System.Windows.Forms.ListBox PlanList;
        private System.Windows.Forms.Label LateralityLabel;
        private System.Windows.Forms.Label SRSLabel;
        private System.Windows.Forms.ListBox LateralityList;
        private System.Windows.Forms.CheckBox SRSCheck;
        private System.Windows.Forms.Label DocLabel;
        private System.Windows.Forms.CheckBox DocCheck;
        private System.Windows.Forms.TextBox DocExplan;
        private System.Windows.Forms.Button ExBut;
    }
}