﻿using calculator.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    class ControlsManager
    {
        // Some... usefull things
        
        // Fonts
        Font textFont = new Font("Verdana", 10.0F, FontStyle.Italic);
        Font labelFont = new Font("Italic", 9.75F, FontStyle.Italic);
        // Sizes of Controls
        Size labelSize = new Size(26, 16); 
        Size boxSize = new Size(38, 23);
        // Gapses between Controls
        public int gapLeft = 38;
        public int gapTop = 38;
        // Control's lists
        public List<List<TextBox>> boxes = new List<List<TextBox>>();
        public List<List<RichTextBox>> labels = new List<List<RichTextBox>>();
        // Constructors
        public ControlsManager()
        {
            StartUp();
        }

        public ControlsManager(Font font)
        {
            labelFont = font;
            StartUp();
        }

        /// <summary>
        /// Возвращает массив коэффициентов
        /// </summary>
        /// <returns>double[,]</returns>
        public double[,] GetArray()
        {
            return ScanArray(boxes);
        }

        /// <summary>
        /// Переводит список списков TextBox в массив double[,]
        /// </summary>
        /// <param name="list"></param>
        /// <returns>double[,]</returns>
        public double[,] ScanArray(List<List<TextBox>> list)
        {
            double[,] array = new double[list.Count, list.Last().Count];
            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < list.Last().Count; j++)
                {
                    if (list[i][j].Text.ToString().First() == '.') // Если первый символ - точка (.123)
                        list[i][j].Text = "0"+ list[i][j].Text; 
                    if (list[i][j].Text.ToString().Last() == '.') // Если последний символ точка (123.)
                        list[i][j].Text += "0";
                    array[i, j] = double.Parse(list[i][j].Text.Replace(".", ",")); // Double кушает только запятые
                }
            return array;
        }

        /// <summary>
        /// Добавялет строку к матрице
        /// </summary>
        public bool AddRow()
        {
            if (boxes.Count < 10)
            {
                // Fill the class with clone
                List<TextBox> boxRow = boxes.Last();
                List<RichTextBox> labelRow = labels.Last();

                boxes.Add(CloneBoxes());      // Clone boxes
                labels.Add(CloneLabels());    // Clone labels
                for (int i = 0; i < labels.Last().Count; i++) // Draw new boxes
                {
                    boxes.Last()[i].Text = "0";             // Set the Text to "0"
                    boxes.Last()[i].Top += gapTop;          // Place new box lower
                    labels.Last()[i].Top += gapTop;          // Place new label lower
                }
                // boxes.Count = labels.Count +1
                boxes.Last().Last().Text = "0";             // Set the Text to "0"
                boxes.Last().Last().Top += gapTop;          // Place new box lower
                return true;
            }
            return false;
        }

        public bool DelRow()
        {
            if (boxes.Count > 3)
            {
                foreach (TextBox box in boxes.Last())
                    box.Dispose();
                foreach (RichTextBox label in labels.Last())
                    label.Dispose();
                boxes.RemoveAt(boxes.Count - 1);
                labels.RemoveAt(labels.Count - 1);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Добавляет столбец к матрице
        /// </summary>
        [Obsolete("This method is deprecated, we haven't another one, but just don't use it anyway...")]
        public void AddColumn()
        {
            int left = 0;
            int top = 0;
            for (int i = 0; i < labels.Count; i++) //
            {
                labels[i].Last().Text = "X" + labels[i].Count.ToString() + "+"; // Fix last label's Text
                left = boxes[i].Last().Left + gapLeft;  // Define left for label
                top = labels[i].Last().Top;             // Define top position of label
                labels[i].Add(AddLabel(left, top, "X" + (labels[i].Count + 1).ToString() + "=")); // Add new label to list
                top = boxes[i].Last().Top + 3;            // Define top position of textBox
                boxes[i].Add(AddBox(left + labels[i].Last().Size.Width, top)); // Add new TextBox to list
            }
        }

        /// <summary>
        /// Составляет начальную таблицу
        /// </summary>
        public void StartUp()
        {
            List<TextBox> rowBox;
            List<RichTextBox> rowLabel;
            int left;
            int top = 50;
            RichTextBox label;
            for (int j = 0; j < 3; j++)
            {
                rowBox = new List<TextBox>();
                rowLabel = new List<RichTextBox>();
                left = 50;
                for (int i = 0; i < 3; i++)
                {
                    rowBox.Add(AddBox(left, j * gapTop + top));
                    if (i == 3 - 1)
                        label = AddLabel(left + gapLeft, j * gapTop + top, "X" + (i + 1).ToString() + "=");
                    else label = AddLabel(left + gapLeft, j * gapTop + top, "X" + (i + 1).ToString() + "+");
                    rowLabel.Add(label);
                    left += gapLeft + labelSize.Width;
                }
                rowBox.Add(AddBox(left, j * gapTop + top));
                boxes.Add(rowBox);
                labels.Add(rowLabel);
            }
        }

        /// <summary>
        /// Clone boxes list (List<TextBox>)
        /// </summary>
        /// <returns>List<TextBox></returns>
        public List<TextBox> CloneBoxes()
        {
            List<TextBox> newBoxes = new List<TextBox>();
            TextBox newbox;
            foreach (TextBox box in boxes.Last())
            {
                newbox = AddBox(box.Left, box.Top+3);
                newBoxes.Add(newbox);
            }
            return newBoxes;
        }

        /// <summary>
        /// Clone labels list (List<Labels>)
        /// </summary>
        /// <returns>List<Label></returns>
        public List<RichTextBox> CloneLabels()
        {
            List<RichTextBox> newLabels = new List<RichTextBox>();
            RichTextBox newlabel;
            foreach (RichTextBox label in labels.Last())
            {
                newlabel = AddLabel(label.Left, label.Top, label.Text);
                newLabels.Add(newlabel);
            }
            return newLabels;
        }

        /// <summary>
        /// Создаёт новый textBox
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <returns>TextBox</returns>
        public TextBox AddBox(int left, int top)
        {
            TextBox textBox = new TextBox();
            textBox.Font = textFont;
            textBox.Size = boxSize;
            textBox.Top = top - 3;
            textBox.Left = left;
            textBox.Text = "0";
            textBox.KeyPress += KeyHandler;
            textBox.PreviewKeyDown += new PreviewKeyDownEventHandler(BoxPreviewKeyDown);
            return textBox;
        }

        /// <summary>
        /// Создаёт новый Label
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <returns>Label</returns>
        public RichTextBox AddLabel(int left, int top, string info)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Font = labelFont;
            richTextBox.BorderStyle = BorderStyle.None;
            richTextBox.BackColor = Color.WhiteSmoke;
            richTextBox.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox.ReadOnly = true;
            richTextBox.ShortcutsEnabled = false;
            richTextBox.GotFocus += RTBFocus;
            richTextBox.Size = labelSize;
            richTextBox.Top = top;
            richTextBox.Left = left;
            richTextBox.Text = info;
            return richTextBox;
        }

        public void RTBFocus(Object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            int j = (rtb.Top - labels.First().First().Top)/gapTop;
            int i = (rtb.Left - boxes.First().First().Left) / (gapLeft + labelSize.Width);
            boxes[j][i].Focus();
        }

        /// <summary>
        /// TextBox.KeyPress Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void KeyHandler(object sender, KeyPressEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (e.KeyChar == ',') e.KeyChar = '.';
            if (e.KeyChar != (char)Keys.Back)
            // Если введена не цифра, не точка, либо вторая точка
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' || e.KeyChar == '.' && box.Text.Contains("."))
                e.Handled = true;
        }

        /// <summary>
        /// Делает стрелки вверх/вниз юзабельными (превьюшка нажатий)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    e.IsInputKey = true;
                    break;
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
                default: 
                    break;
            }
        }
    }
}
