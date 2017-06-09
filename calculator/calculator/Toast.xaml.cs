using System.Windows;
using System;
using System.Windows.Threading;
using System.Xaml;

namespace calculator
{
    /// <summary>
    /// Interaction logic for Toast.xaml
    /// </summary>
    public partial class Toast
    {
        public Toast(string text, string info)
        {
            InitializeComponent();
            this.info.Text = info;
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
            //Application.Current.Shutdown();
        }
    }
}
