namespace calculator
{
    partial class Form1
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
            this.btnAddRaw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddRaw
            // 
            this.btnAddRaw.Location = new System.Drawing.Point(212, 189);
            this.btnAddRaw.Name = "btnAddRaw";
            this.btnAddRaw.Size = new System.Drawing.Size(70, 45);
            this.btnAddRaw.TabIndex = 1;
            this.btnAddRaw.Text = "btnAddRaw";
            this.btnAddRaw.UseVisualStyleBackColor = true;
            this.btnAddRaw.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(518, 259);
            this.Controls.Add(this.btnAddRaw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddRaw;
    }
}

