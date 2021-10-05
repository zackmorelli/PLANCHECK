namespace PLANCHECK_STANDALONE
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
            this.button1 = new System.Windows.Forms.Button();
            this.Datefromlabel = new System.Windows.Forms.Label();
            this.DateFrom = new System.Windows.Forms.TextBox();
            this.DateToLabel = new System.Windows.Forms.Label();
            this.DateTo = new System.Windows.Forms.TextBox();
            this.DateFormat = new System.Windows.Forms.Label();
            this.Directions = new System.Windows.Forms.TextBox();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(5, 497);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // Datefromlabel
            // 
            this.Datefromlabel.AutoSize = true;
            this.Datefromlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datefromlabel.Location = new System.Drawing.Point(12, 207);
            this.Datefromlabel.Name = "Datefromlabel";
            this.Datefromlabel.Size = new System.Drawing.Size(84, 20);
            this.Datefromlabel.TabIndex = 9;
            this.Datefromlabel.Text = "Date from:";
            // 
            // DateFrom
            // 
            this.DateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFrom.Location = new System.Drawing.Point(93, 204);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Size = new System.Drawing.Size(101, 26);
            this.DateFrom.TabIndex = 10;
            // 
            // DateToLabel
            // 
            this.DateToLabel.AutoSize = true;
            this.DateToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateToLabel.Location = new System.Drawing.Point(231, 207);
            this.DateToLabel.Name = "DateToLabel";
            this.DateToLabel.Size = new System.Drawing.Size(31, 20);
            this.DateToLabel.TabIndex = 11;
            this.DateToLabel.Text = "To:";
            // 
            // DateTo
            // 
            this.DateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTo.Location = new System.Drawing.Point(259, 201);
            this.DateTo.Name = "DateTo";
            this.DateTo.Size = new System.Drawing.Size(101, 26);
            this.DateTo.TabIndex = 12;
            this.DateTo.TextChanged += new System.EventHandler(this.DateTo_TextChanged);
            // 
            // DateFormat
            // 
            this.DateFormat.AutoSize = true;
            this.DateFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFormat.Location = new System.Drawing.Point(382, 210);
            this.DateFormat.Name = "DateFormat";
            this.DateFormat.Size = new System.Drawing.Size(206, 20);
            this.DateFormat.TabIndex = 13;
            this.DateFormat.Text = "Date format: YYYY-MM-DD";
            // 
            // Directions
            // 
            this.Directions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Directions.Location = new System.Drawing.Point(5, 3);
            this.Directions.Multiline = true;
            this.Directions.Name = "Directions";
            this.Directions.ReadOnly = true;
            this.Directions.Size = new System.Drawing.Size(601, 187);
            this.Directions.TabIndex = 15;
            this.Directions.Text = resources.GetString("Directions.Text");
            // 
            // OutputBox
            // 
            this.OutputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputBox.Location = new System.Drawing.Point(12, 246);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputBox.Size = new System.Drawing.Size(594, 230);
            this.OutputBox.TabIndex = 17;
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(5, 556);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(601, 21);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 18;
            this.pBar.Visible = false;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 584);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.Directions);
            this.Controls.Add(this.DateFormat);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.DateToLabel);
            this.Controls.Add(this.DateFrom);
            this.Controls.Add(this.Datefromlabel);
            this.Controls.Add(this.button1);
            this.Name = "GUI";
            this.Text = "External Beam Plan Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Datefromlabel;
        private System.Windows.Forms.TextBox DateFrom;
        private System.Windows.Forms.Label DateToLabel;
        private System.Windows.Forms.TextBox DateTo;
        private System.Windows.Forms.Label DateFormat;
        private System.Windows.Forms.TextBox Directions;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.ProgressBar pBar;
    }
}

