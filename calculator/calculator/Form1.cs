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

        int gapLeft = 38;
        int gapTop = 38;

        List<List<TextBox>> boxes = new List<List<TextBox>>();
        List<List<Label>> labels = new List<List<Label>>();
        AddAndClone stuff = new AddAndClone();

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            StartUp();
            DrawControls();
        }

        /// <summary>
        /// Добавляет столбец к матрице
        /// </summary>
        public void AddColumn()
        {
            int left = 0;
            int top = 0;
            for (int i=0; i< labels.Count; i++) //
            {
                labels[i].Last().Text = "X" + labels[i].Count.ToString() + "+"; // Fix last label's Text
                left = boxes[i].Last().Left + gapLeft;  // Define left for label
                top = labels[i].Last().Top;             // Define top position of label
                labels[i].Add(stuff.AddLabel(left, top, "X" + (labels[i].Count+1).ToString() + "=")); // Add new label to list
                DrawOneControl(labels[i].Last());       // Draw new Label
                top = boxes[i].Last().Top+3;            // Define top position of textBox
                boxes[i].Add(stuff.AddBox(left + labels[i].Last().Size.Width, top)); // Add new TextBox to list
                DrawOneControl(boxes[i].Last());        // Draw new TextBox
            }
        }

        /// <summary>
        /// Добавялет строку к матрице
        /// </summary>
        public void AddRow()
        {
            // Fill the class with clone
            stuff.boxes = boxes.Last();
            stuff.labels = labels.Last();
            //
            boxes.Add(stuff.CloneBoxes());      // Clone
            labels.Add(stuff.CloneLabels());    // Clone
            for (int i = 0; i < boxes.Last().Count; i++) // Draw new boxes
            {
                boxes.Last()[i].Text = "0";             // Set the Text to "0"
                boxes.Last()[i].Top += gapTop;          // Place new box lower
                DrawOneControl(boxes.Last()[i]);
            }
            for (int i = 0; i < labels.Last().Count; i++) // Draw new labels
            {
                labels.Last()[i].Top += gapTop;          // Place new label lower
                DrawOneControl(labels.Last()[i]);
            }
        }

        /// <summary>
        /// Отрисовывает все контролы
        /// </summary>
        public void DrawControls()
        {
            foreach (List<TextBox> box in boxes)
                this.Controls.AddRange(box.ToArray());
            foreach (List<Label> label in labels)
                this.Controls.AddRange(label.ToArray());
        }

        /// <summary>
        /// Отрисовывает на форме контрол
        /// </summary>
        /// <param name="control"></param>
        public void DrawOneControl(Control control)
        {
            this.Controls.Add(control);
        }

        /// <summary>
        /// Составляет начальную таблицу
        /// </summary>
        public void StartUp()
        {
            List<TextBox> rowBox;
            List<Label> rowLabel;
            int left;
            int top=20;
            Label label;
            for (int j = 0; j < 3; j++)
            {
                rowBox = new List<TextBox>();
                rowLabel = new List<Label>();
                left = 50;
                for (int i = 0; i < 3; i++)
                {
                    rowBox.Add(stuff.AddBox(left, j * gapTop + top));
                    if (i == 3-1)
                        label = stuff.AddLabel(left + gapLeft, j * gapTop + top, "X" + (i + 1).ToString() + "=");
                    else label = stuff.AddLabel(left + gapLeft, j * gapTop + top, "X" + (i + 1).ToString() + "+");
                    rowLabel.Add(label);
                    left += gapLeft + label.Text.ToString().Length * (int)stuff.labelFont.SizeInPoints;
                }
                rowBox.Add(stuff.AddBox(left, j * gapTop + top));
                boxes.Add(rowBox);
                labels.Add(rowLabel);
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
            if (boxes.Last().Last().Top>= btnAddRaw.Top) btnAddRaw.Top += gapTop;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
