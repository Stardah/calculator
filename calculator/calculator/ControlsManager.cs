using calculator.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

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
        // Triggers
        static bool connected;
        public bool Connected
        {
            get
            {
                CheckInternetConnection();
                return connected;
            }
        }
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
        private List<Toast> toasts;
        // Calculator itself
        Calculator calc;
        Wolfram wolf = new Wolfram();
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
            CheckInternetConnection();
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
        public double[,] GetCoeffs()
        {
            return ScanArray(true);
        }

        static async void CheckInternetConnection()
        {
            connected = await CheckInternetConnectionAsync();
        }

        public static Task<bool> CheckInternetConnectionAsync()
        {
            return Task<bool>.Run(() => {
                try
                {
                    using (var client = new WebClient())
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            });
        }


        /// <summary>
        /// Переводит список списков TextBox в массив double[,]
        /// </summary>
        /// <param name="list"></param>
        /// <param name="coeffs">Выводить коэффициенты или свободные члены</param>
        /// <returns>double[,]</returns>
        private double[,] ScanArray(bool coeffs)
        {
            int jstart = 0;
            int jend = 3;
            if (!coeffs)
            {
                jstart = 3;
                jend = 4;
            }
            double[,] array = new double[boxes.Count, jend - jstart];
            for (int i = 0; i < boxes.Count; i++)
                for (int j = jstart; j < jend; j++)
                {
                    if (boxes[i][j].Text == "")
                        boxes[i][j].Text = "0";
                    if (boxes[i][j].Text.ToString().First() == '.') // Если первый символ - точка (.123)
                        boxes[i][j].Text = "0"+ boxes[i][j].Text; 
                    if (boxes[i][j].Text.ToString().Last() == '.') // Если последний символ точка (123.)
                        boxes[i][j].Text += "0";
                    if (boxes[i][j].Text.Contains("-")) // Если минус где попало
                    {
                        boxes[i][j].Text = boxes[i][j].Text.Replace("-", "");
                        boxes[i][j].Text = "-"+ boxes[i][j].Text;
                    }
                    if (boxes[i][j].Text.ToString().Length > 8) boxes[i][j].Text = boxes[i][j].Text.ToString().Remove(8);
                    array[i, j - jstart] = double.Parse(boxes[i][j].Text.Replace(".", ",")); // Double кушает только запятые
                }
            return array;
        }

        private string SystemToString()
        {
            string[] array = new string[boxes.Count];
            for (int i = 0; i < boxes.Count; i++)
            {
                for (int j = 0; j < labels.Last().Count; j++)
                {
                    array[i] += boxes[i][j].Text.Replace(".", ","); // Double кушает только запятые
                    array[i] += "*"+labels[i][j].Text;
                }
                array[i] += boxes[i].Last().Text.Replace(".",",");
            }
            return "Solve[{" + array[0]+","+ "" + array[1] + ","+ "" + array[2] + "},{X1,X2,X3}]";
        }

        /// <summary>
        /// Решает систему и выводит результат
        /// </summary>
        /// <returns></returns>
        public List<string> Solve()
        {
            CheckInternetConnection();
            double[] solution;
            List<string> output = new List<string>();
            double[,] free = ScanArray(false);
            try
            {
                calc = new Calculator(ScanArray(true));
                calc[0] = free[0, 0];
                calc[1] = free[1, 0];
                calc[2] = free[2, 0];
                solution = calc.Solve(); // Запрашиваем решение

                if (solution[0] + solution[1] + solution[2] != 0)
                {
                    foreach (double num in solution)
                        output.Add(num.ToString());
                }
                else
                {
                    string input = ""+SystemToString();//[//math:${input1}//],[//math:${input2}//],[//math:${input3}//]
                    List<string> text = wolf.SolveSystem(input);
                    if (text[0] != "C1")
                        output = text;
                    else
                        foreach (double num in solution)
                            output.Add("0");
                    ShowToast("Значение получено", "Готово");
                    //ShowToast("Не удалось найти значение выражения", "Оказия");
                }
            }
            catch (Exception e)
            {
                ShowToast(e.Message.ToString(),"Оказия");
                output = new List<string> { "C1","C2","C3"};
            }
            return output;   
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
            UpdateToasts();
            toasts.Add(new Toast(text, header));
            toasts.Last().Left = left + formWidth/2 - toasts.Last().Width / 2 + toastLeftMargin;
            toasts.Last().Top = top + formHeight - toastTopMargin;
            toasts.Last().Show();
        }

        public void ShowToast(string text, string info)
        {
            
            int top = formTop;
            if (toasts.Count != 0)
            {
                top -= 55 * toasts.Count;
            }

            toasts.Add(
                new Toast(text, info,
                formLeft + formWidth / 2 + toastLeftMargin,
                top + formHeight - toastTopMargin
             )
            );
        }

        public int UpdateToasts()
        {
            int count = 0;
            int i = 0;
            while (i < toasts.Count)
            {
                if (!toasts[i].Shown)
                {
                    toasts[i].Close();
                    toasts.Remove(toasts[i]);
                }
                else
                {
                    toasts[i].Top = formTop + formHeight - toastTopMargin - 55*i;
                    i++;
                    count++;
                }
            }
            return count;
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
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' & e.KeyChar != '-' || e.KeyChar == '.' && box.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                if (e.KeyChar == '-')
                {
                    e.Handled = true;
                    if(!box.Text.Contains("-")) box.Text = "-" + box.Text;
                } 
            }
            // Воод не более 8 символов
            if (box.Text.ToString().Length > 8) e.Handled = true;
        }

        /// <summary>
        /// Выделяет весь текст при нажатии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
