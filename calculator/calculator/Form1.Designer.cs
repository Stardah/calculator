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
            this.btnAddRaw.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAddRaw.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddRaw.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddRaw.ForeColor = System.Drawing.Color.White;
            this.btnAddRaw.Location = new System.Drawing.Point(89, 164);
            this.btnAddRaw.Name = "btnAddRaw";
            this.btnAddRaw.Size = new System.Drawing.Size(155, 28);
            this.btnAddRaw.TabIndex = 1;
            this.btnAddRaw.Text = "Добавить строку";
            this.btnAddRaw.UseVisualStyleBackColor = false;
            this.btnAddRaw.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(353, 204);
            this.Controls.Add(this.btnAddRaw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddRaw;
    }
}

