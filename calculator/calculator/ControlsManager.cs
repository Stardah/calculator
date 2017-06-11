using calculator.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    /// <summary>
    /// by Nikita Terlych
    /// Класс работы с контролами
    /// </summary>
    class ControlsManager
    {
        // Костыль для удобства юзания тостов
        int formLeft = 0;
        int formTop = 0;
        // Const
        int toastTopMargin = 150; // Сдвиг относительно низа формы 
        int toastLeftMargin = 130; // Сдвиг относительно центра формы 
        // Var
        int formWidth;
        int formHeight;
        // Fonts1
        Font textFont = new Font("Verdana", 10.0F, FontStyle.Regular);
        Font labelFont = new Font("Italic", 9.75F, FontStyle.Regular);
        // Sizes of Controls
        Size labelSize = new Size(28, 19);
        Size boxSize = new Size(38, 23);
        // Gapses between Controls
        public int gapLeft
        {
            get
            {
                return 38;
            }
        }
        public int gapTop
        {
            get
            {
                return 38;
            }
        }
        // Control's lists
        public List<List<TextBox>> boxes;
        public List<List<TextBox>> Boxes
        {
            get
            {
                return boxes;
            }
            set
            {
                if (value is List<List<TextBox>>)
                    boxes = value;
            }
        }
        public List<List<RichTextBox>> labels;
        public List<List<RichTextBox>> Labels
        {
            get
            {
                return labels;
            }
            set
            {
                if (value is List<List<RichTextBox>>)
                    labels = value;
            }
        }
        private List<Toast> toasts = new List<Toast>();
        // Constructors
        public ControlsManager(int width, int height)
        {
            this.formWidth = width;
            this.formHeight = height;
            Initialize();
            StartUp();
        }

        public ControlsManager(Font font, int width, int height)
        {
            this.formWidth = width;
            this.formHeight = height;
            labelFont = font;
            Initialize();
            StartUp();
        }

        private void Initialize()
        {
            boxes = new List<List<TextBox>>();
            labels = new List<List<RichTextBox>>();
            toasts = new List<Toast>();
        }

        /// <summary>
        /// Менеджер становится child-free
        /// </summary>
        public void Close()
        {
            for (int i = toasts.Count - 1; i >= 0; i--)
            {
                toasts[i].Close();
                toasts.RemoveAt(i);
            }
        }

        public void Clear()
        {
            foreach (List<TextBox> rowBox in boxes)
                foreach (TextBox box in rowBox)
                    box.Text = "0";
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
        private double[,] ScanArray(List<List<TextBox>> list)
        {
            double[,] array = new double[list.Count, list.Last().Count];
            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < list.Last().Count; j++)
                {
                    if (list[i][j].Text == "")
                        list[i][j].Text = "0";
                    if (list[i][j].Text.ToString().First() == '.') // Если первый символ - точка (.123)
                        list[i][j].Text = "0"+ list[i][j].Text; 
                    if (list[i][j].Text.ToString().Last() == '.') // Если последний символ точка (123.)
                        list[i][j].Text += "0";
                    if (list[i][j].Text.ToString().Length > 8) list[i][j].Text = list[i][j].Text.ToString().Remove(8);
                    array[i, j] = double.Parse(list[i][j].Text.Replace(".", ",")); // Double кушает только запятые
                }
            return array;
        }

        public void Solve(ref RichTextBox box)
        {
            double[] solution;
            List<string> output = new List<string>();
            try
            {
                Calculator calc = new Calculator(GetArray());
                solution = calc.Solve(); // Запрашиваем решение

                foreach (double num in solution)
                    output.Add(num.ToString());
            }
            catch (Exception e)
            {
                ShowToast(e.Message.ToString(),"Оказия");
                output = new List<string> { "C1","C2","C3"};
            }
            // Вывод
            box.SelectionCharOffset = 0;
            box.AppendText("X",Color.White);//x1
            box.AppendText("1",-5, Color.White);
            box.AppendText(" = "+output[0], Color.White);
            box.AppendText("\n");
            box.AppendText("\n",new Font("Verdana", 5.0F, FontStyle.Regular));
            box.AppendText("X", Color.White);//x2
            box.AppendText("2", -5, Color.White);
            box.AppendText(" = " + output[1],Color.White);
            box.AppendText("\n");
            box.AppendText("\n", new Font("Verdana", 5.0F, FontStyle.Regular));
            box.AppendText("X", Color.White);//x3
            box.AppendText("3", -5, Color.White);
            box.AppendText(" = " + output[2], Color.White);    
        }

        /// <summary>
        /// Выводит уведомление
        /// </summary>
        /// <param name="text">Основной текст</param>
        /// <param name="header">Заголовок</param>
        /// <param name="left">Form.Left</param>
        /// <param name="top">Form.Top</param>
        public void ShowToast(string text, string header, int left, int top)
        {
            toasts.Add(new Toast(text, header));
            toasts.Last().Left = left + formWidth/2 - toasts.Last().Width / 2 + toastLeftMargin;
            toasts.Last().Top = top + formHeight - toastTopMargin;
            toasts.Last().Show();
        }

        public void ShowToast(string text, string info)
        {
            toasts.Add(new Toast(text, info));
            toasts.Last().Left = formLeft + formWidth / 2 - toasts.Last().Width / 2 + toastLeftMargin;
            toasts.Last().Top = formTop + formHeight - toastTopMargin;
            toasts.Last().Show();
        }

        /// <summary>
        /// Принимает координаты формы
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void GetCoord(int left, int top)
        {
            this.formLeft = left;
            this.formTop = top;
        }

        /// <summary>
        /// Добавялет строку к матрице
        /// </summary>
        public bool AddRow()
        {
            if (boxes.Count < 4)
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
            if (boxes.Count > 2)
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
                labels[i].Add(AddRichTextBox(left, top, "X" + (labels[i].Count + 1).ToString() + "=")); // Add new label to list
                top = boxes[i].Last().Top + 3;            // Define top position of textBox
                boxes[i].Add(AddBox(left + labels[i].Last().Size.Width, top)); // Add new TextBox to list
            }
        }

        /// <summary>
        /// Составляет начальную таблицу
        /// </summary>
        private void StartUp()
        {
            List<TextBox> rowBox;
            List<RichTextBox> rowLabel;
            int left;
            int top = 70;
            RichTextBox label;
            for (int j = 0; j < 3; j++)
            {
                rowBox = new List<TextBox>();
                rowLabel = new List<RichTextBox>();
                left = 40;
                for (int i = 0; i < 3; i++)
                {
                    rowBox.Add(AddBox(left, j * gapTop + top));
                    label = AddRichTextBox(left + gapLeft, j * gapTop + top, "X");
                    // Оффсет дли индекса
                    label.SelectionCharOffset = -5;
                    // Собственно индекс	
                    label.SelectedText = (i + 1).ToString();
                    // +/=
                    label.SelectionCharOffset = 0;
                    if (i == 3 - 1)
                        label.SelectedText = "=";
                    else label.SelectedText = "+";
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
        private List<TextBox> CloneBoxes()
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
        private List<RichTextBox> CloneLabels()
        {
            List<RichTextBox> newLabels = new List<RichTextBox>();
            RichTextBox newlabel;
            foreach (RichTextBox label in labels.Last())
            {
                newlabel = AddRichTextBox(label.Left, label.Top, label.Text);
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
            textBox.Click += SelectionOnEnter;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.PreviewKeyDown += new PreviewKeyDownEventHandler(BoxPreviewKeyDown);
            return textBox;
        }

        /// <summary>
        /// Создаёт новый RichTextBox
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="info"></param>
        /// <returns>Label</returns>
        private RichTextBox AddRichTextBox(int left, int top, string info)
        {
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Font = labelFont;
            richTextBox.BorderStyle = BorderStyle.None;
            richTextBox.BackColor = Color.WhiteSmoke;
            richTextBox.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox.ReadOnly = true;
            richTextBox.ShortcutsEnabled = false;
            richTextBox.GotFocus += RTBFocus; // Handler
            richTextBox.Size = labelSize;
            richTextBox.Top = top;
            richTextBox.Left = left;
            richTextBox.SelectedText = info;
            return richTextBox;
        }

        /// <summary>
        /// Снимает фокус с RTB и передаёт TextBox'у слева
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RTBFocus(Object sender, EventArgs e)
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
        private void KeyHandler(object sender, KeyPressEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (e.KeyChar == ',') e.KeyChar = '.';
            if (e.KeyChar != (char)Keys.Back)
            {
                // Если введена не цифра, не точка, либо вторая точка
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' || e.KeyChar == '.' && box.Text.Contains("."))
                    e.Handled = true;
                // Воод не более 8 символов
                if (box.Text.ToString().Length > 8) e.Handled = true;
            }
        }

        private void SelectionOnEnter(object sender, System.EventArgs e)
        {
            TextBox box = sender as TextBox;
            if (!String.IsNullOrEmpty(box.Text))
            {
                box.SelectionStart = 0;
                box.SelectionLength = box.Text.Length;
            }
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
