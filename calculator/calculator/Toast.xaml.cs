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
            StartCloseTimer();
        }

        /// <summary>
        /// SetUp AutoClose-Timer
        /// </summary>
        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(4d);
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
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
    }
}
