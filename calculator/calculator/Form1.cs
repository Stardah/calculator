using calculator.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace calculator
{
    /// <summary>
    /// by Nikita Terlych
    /// Класс главной формы приложения
    /// </summary>
    public partial class Form1 : Form
    {
        ControlsManager stuff;
        Wolfram wolf = new Wolfram();
        Point dragOffset;
        Point formLeft;
        Point formTop;

        //Dictionary<string, Font> fonts = new Dictionary<string, Font>();
        PrivateFontCollection fonts = new PrivateFontCollection();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        /*
         * With WS_EX_COMPOSITED set, all descendants of a window get 
         * bottom-to-top painting order using double-buffering. 
         * Bottom-to-top painting order allows a descendent window 
         * to have translucency (alpha) and transparency (color-key) 
         * effects, but only if the descendent window also has 
         * the WS_EX_TRANSPARENT bit set. Double-buffering allows the 
         * window and its descendents to be painted without flicker.
         */
        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            // Раздаём двойную буфферизацию всем потомкам
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
            //
            stuff = new ControlsManager(this.Width, this.Height);
            stuff.GetCoord(this.Left, this.Top);
            DrawControls(stuff.boxes);
            DrawControls(stuff.labels);
            formLeft = new Point(this.Left, this.Width);
            formTop = new Point(this.Top, this.Height);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // Rounded Corners
            InitFont();
            InitControls();
        }

        /// <summary>
        /// Apply fonts
        /// </summary>
        public void InitFont()
        {  
            string fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, Resources.Exo2);   // Записываем ttf из ресурсов в файл
            fonts.AddFontFile(fileName);                    // Загружаем в коллекцию шрифтов
            labelHeader.Font = new Font(fonts.Families[0], 16f, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolve.Font = new Font(fonts.Families[0], 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWolf.Font = new Font(fonts.Families[0], 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWhat.Font = new Font(fonts.Families[0], 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSolution.Font = new Font(fonts.Families[0], 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConnected.Font = new Font(fonts.Families[0], 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
        }

        public void InitControls()
        {
            btnWolf.MouseEnter += btnMouseEnter;
            btnWolf.MouseLeave += btnMouseLeave;
            btnWolf.MouseDown += btnMouseDown;
            btnWolf.MouseUp += btnMouseUp;
            panel1.MouseMove += panelMouseMove;
            panel1.MouseDown += panelMouseDown;
            panel2.MouseMove += panelMouseMove;
            panel2.MouseDown += panelMouseDown;
            panel3.MouseMove += panelMouseMove;
            panel3.MouseDown += panelMouseDown;
            panelSystem.MouseMove += panelMouseMove;
            panelSystem.MouseDown += panelMouseDown;
            ShowInternetStatus();
        }

        public void ShowInternetStatus()
        {
            btnConnected.Checked = stuff.Connected;
        }

        public void CloseForms()
        {
            stuff.Close();
            Application.Exit();
        }

        /// <summary>
        /// Adds new row downside
        /// </summary>
        public void AddRow()
        {
            if (stuff.AddRow())
            {
                for (int i = 0; i < stuff.labels.Last().Count; i++) // Draw new boxes and labels
                {
                    DrawOneControl(stuff.boxes.Last()[i]);
                    DrawOneControl(stuff.labels.Last()[i]);
                }
                DrawOneControl(stuff.boxes.Last().Last()); // boxes.Count = labels.Count +1
                stuff.ShowToast("Строка добавлена", "Готово");
            }
            else stuff.ShowToast("Достигнут предел количества строк", "Оказия");
        }

        /// <summary>
        /// Отрисовывает все TextBox'ы
        /// </summary>
        public void DrawControls(List<List<TextBox>> list)
        {
            foreach (List<TextBox> item in list)
                this.panelSystem.Controls.AddRange(item.ToArray());
        }

        /// <summary>
        /// Отрисовывает все Label'ы
        /// </summary>
        public void DrawControls(List<List<RichTextBox>> list)
        {
            foreach (List<RichTextBox> item in list)
                this.panelSystem.Controls.AddRange(item.ToArray());
        }

        /// <summary>
        /// Отрисовывает на форме один контрол
        /// </summary>
        /// <param name="control"></param>
        public void DrawOneControl(Control control)
        {
            this.panelSystem.Controls.Add(control);
        }

        /// <summary>
        /// Добавляет строку к матрице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
            if (stuff.boxes.Last().Last().Top >= btnAddRaw.Top)
            {
                btnAddRaw.Top += stuff.gapTop;
                btnSolve.Top += stuff.gapTop;
                btnDel.Top += stuff.gapTop;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (stuff.DelRow())
            {
                //btnAddRaw.Top -= stuff.gapTop;
                //btnSolve.Top -= stuff.gapTop;
                //btnDel.Top -= stuff.gapTop;
                stuff.ShowToast("Строка удалена", "Готово");
            }
            else stuff.ShowToast("Нельзя удалить первые две строки", "Оказия");
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            List<string> outs = stuff.Solve();
            out1.Text = outs[0];
            out2.Text = outs[1];
            out3.Text = outs[2];
            ShowInternetStatus();
        }

        // Exit button
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForms();
        }

        // Drag Form
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                dragOffset = this.PointToScreen(e.Location);
                var formLocation = FindForm().Location;
                dragOffset.X -= formLocation.X;
                dragOffset.Y -= formLocation.Y;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                Point newLocation = this.PointToScreen(e.Location);
                newLocation.X -= dragOffset.X;
                newLocation.Y -= dragOffset.Y;
                FindForm().Location = newLocation;
                stuff.GetCoord(this.Left, this.Top);
            }
        }

        private void panelMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragOffset = this.PointToScreen(e.Location);
                var formLocation = FindForm().Location;
                dragOffset.X -= formLocation.X;
                dragOffset.Y -= formLocation.Y;
            }
        }

        private void panelMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point newLocation = this.PointToScreen(e.Location);
                newLocation.X -= dragOffset.X;
                newLocation.Y -= dragOffset.Y;
                FindForm().Location = newLocation;
                stuff.GetCoord(this.Left, this.Top);
            }
        }

        // Эффекты от наведения и нажатий
        private void btnMouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Resources.RoundedButtonLight;
        }

        private void btnMouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Resources.RoundedButton2;
        }

        private void btnMouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Resources.RoundedButtonDown;
        }

        private void btnMouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = Resources.RoundedButton2;
        }

        // Wolfram
        private void btnWolf_Click(object sender, EventArgs e)
        {
            textWolfResult.Text = wolf.SolveThis(textWoldQuery.Text);
            if (textWolfResult.Text != "") stuff.ShowToast("Значение получено", "Wolfram");
            else stuff.ShowToast("Не удалось найти значение выражения", "Wolfram");
            ShowInternetStatus();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            stuff.ShowToast("Решайте системы линейных уравнений!", "Здравствуйте!");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            stuff.Clear();
            stuff.ShowToast("Значения индексов обнулены", "Готово");
        }

        private void btnConnected_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                rb.ForeColor = Color.LimeGreen;
                rb.Text = "Connected";
                stuff.ShowToast("Есть подключение к сети интернет!", "Отлично!");
            }
            else
            {
                rb.ForeColor = Color.MediumPurple;
                rb.Text = "No connection";
                stuff.ShowToast("Подключение к сети интернет разорвано", "Оказия");
            }
        }

        private void btnConnected_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.Checked = stuff.Connected;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            stuff.UpdateToasts();
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            panelExpand.Visible = !panelExpand.Visible;
            stuff.PreviewExpand(ref panelExpand);
        }

        private void panelExpand_MouseClick(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            panel.Visible = false;
        }

        private void btnExpand_MouseEnter(object sender, EventArgs e)
        {
            Button btnExpand = sender as Button;
            btnExpand.BackgroundImage = Resources.arrowWhite;
        }

        private void btnExpand_MouseLeave(object sender, EventArgs e)
        {
            Button btnExpand = sender as Button;
            btnExpand.BackgroundImage = Resources.arrowGold;
        }
    }
}
