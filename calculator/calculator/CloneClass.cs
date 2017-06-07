﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    class AddAndClone
    {
        public Font textFont = new Font("Verdana", 10.0F, FontStyle.Italic);
        public Font labelFont = new Font("Verdana", 9.75F, FontStyle.Italic);

        public List<TextBox> boxes = new List<TextBox>();
        public List<Label> labels;

        public AddAndClone()
        {
        }

        public AddAndClone(List<TextBox> oldboxes)
        {
            boxes = oldboxes;
        }

        public AddAndClone(List<Label> oldlabels)
        {
            labels = oldlabels;
        }

        public AddAndClone(List<TextBox> oldboxes, List<Label> oldlabels)
        {
            boxes = oldboxes;
            labels = oldlabels;
        }

        /// <summary>
        /// Clone boxes list (List<TextBox>)
        /// </summary>
        /// <returns></returns>
        public List<TextBox> CloneBoxes()
        {
            List<TextBox> newBoxes = new List<TextBox>();
            TextBox newbox;
            foreach (TextBox box in boxes)
            {
                newbox = AddBox(box.Left, box.Top+3);
                newBoxes.Add(newbox);
            }
            return newBoxes;
        }

        /// <summary>
        /// Clone labels list (List<Labels>)
        /// </summary>
        /// <returns></returns>
        public List<Label> CloneLabels()
        {
            List<Label> newLabels = new List<Label>();
            Label newlabel;
            foreach (Label label in labels)
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
        /// <returns></returns>
        public TextBox AddBox(int left, int top)
        {
            TextBox textBox = new TextBox();
            textBox.Font = textFont;
            textBox.Size = new Size(38, 23);
            textBox.Top = top - 3;
            textBox.Left = left;
            textBox.Text = "0";
            textBox.KeyDown += KeyHandler;
            textBox.PreviewKeyDown += new PreviewKeyDownEventHandler(BoxPreviewKeyDown);
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

        /// <summary>
        /// TextBox.KeyDown Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void KeyHandler(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                
            }
             //   ;
            //MessageBox.Show("", "");
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
