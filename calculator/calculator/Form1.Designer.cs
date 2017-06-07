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
            this.btnSolve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddRaw
            // 
            this.btnAddRaw.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAddRaw.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddRaw.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddRaw.ForeColor = System.Drawing.Color.White;
            this.btnAddRaw.Location = new System.Drawing.Point(91, 160);
            this.btnAddRaw.Name = "btnAddRaw";
            this.btnAddRaw.Size = new System.Drawing.Size(32, 32);
            this.btnAddRaw.TabIndex = 1;
            this.btnAddRaw.Text = "+";
            this.btnAddRaw.UseVisualStyleBackColor = false;
            this.btnAddRaw.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSolve.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSolve.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSolve.ForeColor = System.Drawing.Color.White;
            this.btnSolve.Location = new System.Drawing.Point(152, 160);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(101, 32);
            this.btnSolve.TabIndex = 2;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(353, 391);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.btnAddRaw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Решение системы уравнений";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddRaw;
        private System.Windows.Forms.Button btnSolve;
    }
}

