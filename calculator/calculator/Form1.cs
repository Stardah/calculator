using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        Font textFont = new Font("Verdana",10.0F,FontStyle.Regular);
        Font labelFont = new Font("Verdana", 10.0F, FontStyle.Bold);

        int gapLeft = 38;
        int gapTop = 38;

        List<List<TextBox>> boxes = new List<List<TextBox>>();
        List<List<Label>> labels = new List<List<Label>>();


        public Form1()
        {
            InitializeComponent();
            StartUp();
            DrawControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Добавляет столбец к матрице
        /// </summary>
        public void AddColumn()
        {
            int left = 0;
            int top = 0;
            for (int i=0; i< labels.Count; i++)
            {
                labels[i].Last().Text = "X" + labels[i].Count.ToString() + "+"; // Fix last label's Text
                left = boxes[i].Last().Left + gapLeft;
                top = labels[i].Last().Top;
                labels[i].Add(AddLabel(left, top, "X" + (labels[i].Count+1).ToString() + "=")); // Add label
                DrawOneControl(labels[i].Last());
                top = boxes[i].Last().Top+3;
                boxes[i].Add(AddBox(left + labels[i].Last().Size.Width, top));//labels[i].Last().Text.ToString().Length * (int)labelFont.SizeInPoints, top));
                DrawOneControl(boxes[i].Last());
            }
        }

        /// <summary>
        /// Добавялет строку к матрице
        /// </summary>
        public void AddRow()
        {

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
            int top=10;
            int prevLeft;
            Label label;
            for (int j = 0; j < 3; j++)
            {
                rowBox = new List<TextBox>();
                rowLabel = new List<Label>();
                left = 10;
                for (int i = 0; i < 3; i++)
                {
                    rowBox.Add(AddBox(left, j * gapTop + top));
                    if (i == 3-1)
                        label = AddLabel(left + gapLeft, j * gapTop + top, "X" + (i + 1).ToString() + "=");
                    else label = AddLabel(left + gapLeft, j * gapTop + top, "X" + (i + 1).ToString() + "+");
                    rowLabel.Add(label);
                    left += gapLeft + label.Text.ToString().Length * (int)labelFont.SizeInPoints;
                }

                rowBox.Add(AddBox(left, j * gapTop + top));

                boxes.Add(rowBox);
                labels.Add(rowLabel);
            }
        }

        /// <summary>
        /// Создаёт новый textBox
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public TextBox AddBox(int left, int top)
        {
            TextBox textBox = new TextBox();
            textBox.Font = textFont;
            textBox.Size = new Size(38,23);
            textBox.Top = top-3;
            textBox.Left = left;
            textBox.Text = "0";
            return textBox;
        }

        /// <summary>
        /// Создаёт новый Label
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public Label AddLabel(int left, int top, string info)
        {
            Label label = new Label();
            label.Font = labelFont;
            label.FlatStyle = FlatStyle.System;
            label.Size = new Size(38, 16);
            label.Top = top;
            label.Left = left;
            label.Text = info;
            //label.AutoSize = true;
            return label;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddColumn();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(boxes[0][1].Text,"");
        }
    }
}
