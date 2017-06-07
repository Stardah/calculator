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

        List<TextBox> boxes = new List<TextBox>();
        List<Label> labels = new List<Label>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void StartUp()
        {
            
        }

        public TextBox AddText()
        {
            TextBox textBox = new TextBox();
            textBox.Font = textFont;
            return textBox;
        }

        public Label AddLabel()
        {
            Label label = new Label();
            label.Font = labelFont;
            label.FlatStyle = FlatStyle.System;
            return label;
        }
    }
}
