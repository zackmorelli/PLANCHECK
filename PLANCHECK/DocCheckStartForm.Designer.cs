namespace PLANCHECK
{
    partial class DocCheckStartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocCheckStartForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SkipBut = new System.Windows.Forms.Button();
            this.DocCheckInitBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(601, 109);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // SkipBut
            // 
            this.SkipBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkipBut.Location = new System.Drawing.Point(423, 136);
            this.SkipBut.Name = "SkipBut";
            this.SkipBut.Size = new System.Drawing.Size(133, 50);
            this.SkipBut.TabIndex = 1;
            this.SkipBut.Text = "SKIP";
            this.SkipBut.UseVisualStyleBackColor = true;
            this.SkipBut.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // DocCheckInitBut
            // 
            this.DocCheckInitBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocCheckInitBut.Location = new System.Drawing.Point(53, 136);
            this.DocCheckInitBut.Name = "DocCheckInitBut";
            this.DocCheckInitBut.Size = new System.Drawing.Size(211, 55);
            this.DocCheckInitBut.TabIndex = 2;
            this.DocCheckInitBut.Text = "Run DocCheck";
            this.DocCheckInitBut.UseVisualStyleBackColor = true;
            this.DocCheckInitBut.Click += new System.EventHandler(this.DocCheckInitButton_Click);
            // 
            // DocCheckStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 203);
            this.Controls.Add(this.DocCheckInitBut);
            this.Controls.Add(this.SkipBut);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DocCheckStartForm";
            this.Text = "DocCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SkipBut;
        private System.Windows.Forms.Button DocCheckInitBut;
    }
}