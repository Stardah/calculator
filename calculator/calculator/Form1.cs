using calculator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        AddAndClone stuff = new AddAndClone();
        Point dragOffset;

        //Dictionary<string, Font> fonts = new Dictionary<string, Font>();
        PrivateFontCollection fonts = new PrivateFontCollection();

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            InitFont();
            
            DrawControls(stuff.boxes);
            DrawControls(stuff.labels);
        }
        /// <summary>
        /// Apply fonts
        /// </summary>
        public void InitFont()
        {
            // Записываем ttf из ресурсов в файл
            string fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, Resources.Exo2);
            // Загружаем в коллекцию шрифтов
            fonts.AddFontFile(fileName);

            labelHeader.Font = new Font(fonts.Families[0], 16f, FontStyle.Bold, GraphicsUnit.Point, 0);
            //btnAddRaw.Font = new Font(fonts.Families[0], 14f, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolve.Font = new Font(fonts.Families[0], 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
        }



        /// <summary>
        /// Adds new row downside
        /// </summary>
        public void AddRow()
        {
            stuff.AddRow();
            for (int i = 0; i < stuff.labels.Last().Count; i++) // Draw new boxes and labels
            {
                DrawOneControl(stuff.boxes.Last()[i]);
                DrawOneControl(stuff.labels.Last()[i]);
            }
            DrawOneControl(stuff.boxes.Last().Last()); // boxes.Count = labels.Count +1
        }

        /// <summary>
        /// Отрисовывает все TextBox'ы
        /// </summary>
        public void DrawControls(List<List<TextBox>> list)
        {
            foreach (List<TextBox> item in list)
                this.Controls.AddRange(item.ToArray());
        }

        /// <summary>
        /// Отрисовывает все Label'ы
        /// </summary>
        public void DrawControls(List<List<Label>> list)
        {
            foreach (List<Label> item in list)
                this.Controls.AddRange(item.ToArray());
        }

        /// <summary>
        /// Отрисовывает на форме один контрол
        /// </summary>
        /// <param name="control"></param>
        public void DrawOneControl(Control control)
        {
            this.Controls.Add(control);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
            if (stuff.boxes.Last().Last().Top >= btnAddRaw.Top)
            {
                btnAddRaw.Top += stuff.gapTop;
                btnSolve.Top += stuff.gapTop;
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            stuff.GetArray();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Drag Form
        /// </summary>
        /// <param name="e"></param>
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
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragOffset = this.PointToScreen(e.Location);
                var formLocation = FindForm().Location;
                dragOffset.X -= formLocation.X;
                dragOffset.Y -= formLocation.Y;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point newLocation = this.PointToScreen(e.Location);

                newLocation.X -= dragOffset.X;
                newLocation.Y -= dragOffset.Y;

                FindForm().Location = newLocation;
            }
        }

        private void btnSolve_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSolve_MouseEnter(object sender, EventArgs e)
        {
            btnSolve.BackgroundImage = Resources.RoundedButtonLight;
        }

        private void btnSolve_MouseLeave(object sender, EventArgs e)
        {
            btnSolve.BackgroundImage = Resources.RoundedButton2;
        }

        private void btnSolve_MouseDown(object sender, MouseEventArgs e)
        {
            btnSolve.BackgroundImage = Resources.RoundedButtonDown;
        }

        private void btnSolve_MouseUp(object sender, MouseEventArgs e)
        {
            btnSolve.BackgroundImage = Resources.RoundedButton2;
        }
    }
}
