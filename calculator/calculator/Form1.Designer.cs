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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelSystem = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelExpand = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAddRaw = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.panelForLabelUp = new System.Windows.Forms.Panel();
            this.btnExpand = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.out3 = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.out2 = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.out1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConnected = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.labelSolution = new System.Windows.Forms.Label();
            this.labelWhat = new System.Windows.Forms.Label();
            this.btnWolf = new System.Windows.Forms.Button();
            this.textWolfResult = new System.Windows.Forms.TextBox();
            this.textWoldQuery = new System.Windows.Forms.TextBox();
            this.panelSystem.SuspendLayout();
            this.panelForLabelUp.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSystem
            // 
            this.panelSystem.BackColor = System.Drawing.Color.Transparent;
            this.panelSystem.BackgroundImage = global::calculator.Properties.Resources.LightTriangles;
            this.panelSystem.Controls.Add(this.panelExpand);
            this.panelSystem.Controls.Add(this.btnClear);
            this.panelSystem.Controls.Add(this.btnDel);
            this.panelSystem.Controls.Add(this.btnAddRaw);
            this.panelSystem.Controls.Add(this.btnSolve);
            this.panelSystem.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSystem.Location = new System.Drawing.Point(0, 72);
            this.panelSystem.Name = "panelSystem";
            this.panelSystem.Size = new System.Drawing.Size(321, 193);
            this.panelSystem.TabIndex = 11;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panelExpand
            // 
            this.panelExpand.AutoScroll = true;
            this.panelExpand.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panelExpand.BackgroundImage = global::calculator.Properties.Resources.LabelBack;
            this.panelExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelExpand.Location = new System.Drawing.Point(42, 0);
            this.panelExpand.Name = "panelExpand";
            this.panelExpand.Size = new System.Drawing.Size(262, 193);
            this.panelExpand.TabIndex = 12;
            this.panelExpand.Visible = false;
            this.panelExpand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelExpand_MouseClick);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = global::calculator.Properties.Resources.trashbin;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.ForeColor = System.Drawing.Color.Transparent;
            this.btnClear.Location = new System.Drawing.Point(0, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(32, 32);
            this.btnClear.TabIndex = 11;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.BackgroundImage = global::calculator.Properties.Resources.BtnDel;
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(12, 107);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(32, 32);
            this.btnDel.TabIndex = 6;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAddRaw
            // 
            this.btnAddRaw.BackColor = System.Drawing.Color.Transparent;
            this.btnAddRaw.BackgroundImage = global::calculator.Properties.Resources.IconAddFull;
            this.btnAddRaw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddRaw.FlatAppearance.BorderSize = 0;
            this.btnAddRaw.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnAddRaw.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.btnAddRaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRaw.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddRaw.ForeColor = System.Drawing.Color.White;
            this.btnAddRaw.Location = new System.Drawing.Point(12, 149);
            this.btnAddRaw.Name = "btnAddRaw";
            this.btnAddRaw.Size = new System.Drawing.Size(32, 32);
            this.btnAddRaw.TabIndex = 1;
            this.btnAddRaw.UseVisualStyleBackColor = false;
            this.btnAddRaw.Visible = false;
            this.btnAddRaw.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.BackColor = System.Drawing.Color.Transparent;
            this.btnSolve.BackgroundImage = global::calculator.Properties.Resources.RoundedButton2;
            this.btnSolve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSolve.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSolve.FlatAppearance.BorderSize = 0;
            this.btnSolve.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSolve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolve.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.ForeColor = System.Drawing.Color.White;
            this.btnSolve.Location = new System.Drawing.Point(51, 150);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(218, 32);
            this.btnSolve.TabIndex = 2;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = false;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            this.btnSolve.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMouseDown);
            this.btnSolve.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            this.btnSolve.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            this.btnSolve.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMouseUp);
            // 
            // panelForLabelUp
            // 
            this.panelForLabelUp.BackColor = System.Drawing.Color.DarkViolet;
            this.panelForLabelUp.BackgroundImage = global::calculator.Properties.Resources.Header2;
            this.panelForLabelUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelForLabelUp.Controls.Add(this.btnExpand);
            this.panelForLabelUp.Controls.Add(this.label7);
            this.panelForLabelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForLabelUp.Location = new System.Drawing.Point(0, 27);
            this.panelForLabelUp.Name = "panelForLabelUp";
            this.panelForLabelUp.Size = new System.Drawing.Size(321, 45);
            this.panelForLabelUp.TabIndex = 13;
            // 
            // btnExpand
            // 
            this.btnExpand.BackColor = System.Drawing.Color.Transparent;
            this.btnExpand.BackgroundImage = global::calculator.Properties.Resources.arrowGold;
            this.btnExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpand.FlatAppearance.BorderSize = 0;
            this.btnExpand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExpand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExpand.ForeColor = System.Drawing.Color.White;
            this.btnExpand.Location = new System.Drawing.Point(268, 7);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(32, 32);
            this.btnExpand.TabIndex = 12;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            this.btnExpand.MouseEnter += new System.EventHandler(this.btnExpand_MouseEnter);
            this.btnExpand.MouseLeave += new System.EventHandler(this.btnExpand_MouseLeave);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(321, 45);
            this.label7.TabIndex = 10;
            this.label7.Text = "Система уравнений";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::calculator.Properties.Resources.LabelBack;
            this.panel1.Controls.Add(this.out3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.out2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.out1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(321, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 238);
            this.panel1.TabIndex = 3;
            // 
            // out3
            // 
            this.out3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.out3.Location = new System.Drawing.Point(86, 149);
            this.out3.Multiline = false;
            this.out3.Name = "out3";
            this.out3.ReadOnly = true;
            this.out3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.out3.Size = new System.Drawing.Size(145, 21);
            this.out3.TabIndex = 12;
            this.out3.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(54, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 23);
            this.label11.TabIndex = 11;
            this.label11.Text = "=";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(42, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 18);
            this.label12.TabIndex = 10;
            this.label12.Text = "3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(25, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 23);
            this.label13.TabIndex = 9;
            this.label13.Text = "X";
            // 
            // out2
            // 
            this.out2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.out2.Location = new System.Drawing.Point(86, 112);
            this.out2.Multiline = false;
            this.out2.Name = "out2";
            this.out2.ReadOnly = true;
            this.out2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.out2.Size = new System.Drawing.Size(145, 21);
            this.out2.TabIndex = 8;
            this.out2.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(54, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(42, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(25, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 23);
            this.label10.TabIndex = 5;
            this.label10.Text = "X";
            // 
            // out1
            // 
            this.out1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.out1.Location = new System.Drawing.Point(86, 73);
            this.out1.Multiline = false;
            this.out1.Name = "out1";
            this.out1.ReadOnly = true;
            this.out1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.out1.Size = new System.Drawing.Size(145, 21);
            this.out1.TabIndex = 4;
            this.out1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(54, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(42, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(25, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.Color.White;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelHeader.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Image = global::calculator.Properties.Resources.Header2;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(265, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Решение";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.btnConnected);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 27);
            this.panel2.TabIndex = 5;
            // 
            // btnConnected
            // 
            this.btnConnected.AutoCheck = false;
            this.btnConnected.AutoSize = true;
            this.btnConnected.BackColor = System.Drawing.Color.Transparent;
            this.btnConnected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnConnected.FlatAppearance.BorderSize = 0;
            this.btnConnected.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnConnected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btnConnected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnConnected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnected.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnConnected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnected.Location = new System.Drawing.Point(4, 5);
            this.btnConnected.Name = "btnConnected";
            this.btnConnected.Size = new System.Drawing.Size(94, 17);
            this.btnConnected.TabIndex = 13;
            this.btnConnected.Text = "No connection";
            this.btnConnected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnected.UseVisualStyleBackColor = false;
            this.btnConnected.CheckedChanged += new System.EventHandler(this.btnConnected_CheckedChanged);
            this.btnConnected.Click += new System.EventHandler(this.btnConnected_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::calculator.Properties.Resources.closeSQR;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(560, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.BackgroundImage = global::calculator.Properties.Resources.LabelBack;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.labelSolution);
            this.panel3.Controls.Add(this.labelWhat);
            this.panel3.Controls.Add(this.btnWolf);
            this.panel3.Controls.Add(this.textWolfResult);
            this.panel3.Controls.Add(this.textWoldQuery);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 265);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(586, 95);
            this.panel3.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(278, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "=";
            // 
            // labelSolution
            // 
            this.labelSolution.AutoSize = true;
            this.labelSolution.BackColor = System.Drawing.Color.Transparent;
            this.labelSolution.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSolution.ForeColor = System.Drawing.Color.White;
            this.labelSolution.Location = new System.Drawing.Point(380, 11);
            this.labelSolution.Name = "labelSolution";
            this.labelSolution.Size = new System.Drawing.Size(73, 16);
            this.labelSolution.TabIndex = 9;
            this.labelSolution.Text = "Решение";
            // 
            // labelWhat
            // 
            this.labelWhat.AutoSize = true;
            this.labelWhat.BackColor = System.Drawing.Color.Transparent;
            this.labelWhat.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWhat.ForeColor = System.Drawing.Color.White;
            this.labelWhat.Location = new System.Drawing.Point(125, 11);
            this.labelWhat.Name = "labelWhat";
            this.labelWhat.Size = new System.Drawing.Size(95, 16);
            this.labelWhat.TabIndex = 4;
            this.labelWhat.Text = "Выражение";
            // 
            // btnWolf
            // 
            this.btnWolf.BackColor = System.Drawing.Color.Transparent;
            this.btnWolf.BackgroundImage = global::calculator.Properties.Resources.RoundedButton2;
            this.btnWolf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWolf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnWolf.FlatAppearance.BorderSize = 0;
            this.btnWolf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnWolf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnWolf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWolf.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWolf.ForeColor = System.Drawing.Color.White;
            this.btnWolf.Location = new System.Drawing.Point(215, 59);
            this.btnWolf.Name = "btnWolf";
            this.btnWolf.Size = new System.Drawing.Size(150, 24);
            this.btnWolf.TabIndex = 7;
            this.btnWolf.Text = "Wolfram";
            this.btnWolf.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWolf.UseVisualStyleBackColor = false;
            this.btnWolf.Click += new System.EventHandler(this.btnWolf_Click);
            // 
            // textWolfResult
            // 
            this.textWolfResult.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textWolfResult.Location = new System.Drawing.Point(310, 30);
            this.textWolfResult.Name = "textWolfResult";
            this.textWolfResult.Size = new System.Drawing.Size(201, 23);
            this.textWolfResult.TabIndex = 8;
            // 
            // textWoldQuery
            // 
            this.textWoldQuery.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textWoldQuery.Location = new System.Drawing.Point(71, 30);
            this.textWoldQuery.Name = "textWoldQuery";
            this.textWoldQuery.Size = new System.Drawing.Size(201, 23);
            this.textWoldQuery.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 360);
            this.Controls.Add(this.panelSystem);
            this.Controls.Add(this.panelForLabelUp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panelSystem.ResumeLayout(false);
            this.panelForLabelUp.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddRaw;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox textWoldQuery;
        private System.Windows.Forms.Button btnWolf;
        private System.Windows.Forms.TextBox textWolfResult;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelWhat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelSolution;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelSystem;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox out1;
        private System.Windows.Forms.RichTextBox out3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox out2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton btnConnected;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Panel panelForLabelUp;
        private System.Windows.Forms.Panel panelExpand;
    }
}

