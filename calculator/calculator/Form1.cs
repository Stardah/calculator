using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            DrawControls(stuff.boxes);
            DrawControls(stuff.labels);
        }

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
    }
}
