using System.Windows;
using System;
using System.Windows.Threading;
using System.Xaml;

namespace calculator
{
    /// <summary>
    /// by Nikita Terlych
    /// Класс уведомлений
    /// </summary>
    public partial class Toast : Window
    {
        bool shown = true;
        public bool Shown
        {
            get
            {
                return shown;
            }
        }
        /// <summary>
        /// Выкатывает тост с заданным текстом и заголовком
        /// </summary>
        /// <param name="text"></param>
        /// <param name="header"></param>
        public Toast(string text, string header)
        {
            InitializeComponent();
            this.info.Text = header;
            this.text.Text = text;
            this.Show();
            StartCloseTimer();
        }

        public Toast(string text, string header, int left, int top)
        {
            InitializeComponent();
            this.info.Text = header;
            this.text.Text = text;
            this.Left = left - this.Width/2;
            this.Top = top;
            this.Activate();
            this.Show();
            this.Topmost = true;
            StartCloseTimer();
        }

        /// <summary>
        /// SetUp AutoClose-Timer
        /// </summary>
        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3d);
            timer.Tick += TimerTick;
            timer.Start();
        }

        /// <summary>
        /// AutoClose-Timer Tick
        /// </summary>
        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            shown = false;
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
    }
}
